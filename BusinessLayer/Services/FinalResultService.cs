using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class FinalResultService : IFinalResultService
    {


        private readonly IGenericRepository GenericRepository;
        private readonly ILogger Logger;
        private IStudentService StudentService;
        public FinalResultService(IGenericRepository GenericRepository, ILoggerFactory Logger, IStudentService StudentService)
        {
            this.GenericRepository = GenericRepository;
            this.StudentService = StudentService;
            this.Logger = Logger.CreateLogger("UserServiceLogger");
        }

        public void Add(FinalResultModel finalResultModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == finalResultModel.Student.Id).FirstOrDefault();
            var finalResultEntity = new FinalResultEntity(finalResultModel.Id, null, finalResultModel.Student.Id, finalResultModel.Status);
            uof.Add<FinalResultEntity>(finalResultEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var finalResultEntity = GenericRepository.Get<FinalResultEntity>().Where(finalResult => finalResult.Id == Id).FirstOrDefault();
            if (finalResultEntity != null)
            {
                uof.Delete<FinalResultEntity>(finalResultEntity);
                uof.SaveChanges();
            }
            else throw new Exception();
        }

        public List<FinalResultModel> GetAll()
        {
            var finalResultEntities = GenericRepository.Get<FinalResultEntity>().ToList();
            var finalResultModels = new List<FinalResultModel>();
            foreach (var finalResultEntity in finalResultEntities)
            {
                var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == finalResultEntity.StudentId).FirstOrDefault();
                var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();

                var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
                var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.Group, studentEntity.FullName, studentEntity.Hobby);
                var finalResultModel = new FinalResultModel(finalResultEntity.Id, studentModel, finalResultEntity.Status);

                finalResultModels.Add(finalResultModel);
            }
            return finalResultModels;
        }

        public FinalResultModel GetById(int Id)
        {

            var finalResultEntity = GenericRepository.Get<FinalResultEntity>().Where(finalResult => finalResult.Id == Id).FirstOrDefault();
            if (finalResultEntity == null) throw new Exception();

            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == finalResultEntity.StudentId).FirstOrDefault();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();

            var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
            var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.Group, studentEntity.FullName, studentEntity.Hobby);
            var finalResultModel = new FinalResultModel(finalResultEntity.Id, studentModel, finalResultEntity.Status);

            return finalResultModel;
        }

        public void Update(int Id, FinalResultModel finalResultModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var finalResultEntity = GenericRepository.Get<FinalResultEntity>().Where(finalResult => finalResult.Id == Id).FirstOrDefault();
            if (finalResultEntity != null)
            {
                var studentModel = finalResultModel.Student;
                var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentModel.User.Id).FirstOrDefault();
                var studentEntity = new StudentEntity(studentModel.Id, userEntity, studentModel.Group, studentModel.FullName, studentModel.Hobby);
                var newFinalResultEntity = new FinalResultEntity(Id, studentEntity, finalResultModel.Status);
                uof.Update<FinalResultEntity>(newFinalResultEntity);
                uof.SaveChanges();
            }
            else throw new Exception();
        }
    }
}
