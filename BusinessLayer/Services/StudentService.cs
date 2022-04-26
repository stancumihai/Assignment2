using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository GenericRepository;

        public StudentService(IGenericRepository genericRepository)
        {
            GenericRepository = genericRepository;
        }

        public void Add(StudentModel studentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentModel.User.Id).FirstOrDefault();
            var studentEntity = new StudentEntity(studentModel.Id, null, studentModel.User.Id, studentModel.FullName, studentModel.Group, studentModel.Hobby);
            uof.Add<StudentEntity>(studentEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                uof.Delete<StudentEntity>(studentEntity);
                uof.SaveChanges();
            }
        }

        public List<StudentModel> GetAll()
        {
            var studentEntities = GenericRepository.Get<StudentEntity>().ToList();
            var studentModels = new List<StudentModel>();
            foreach (var studentEntity in studentEntities)
            {
                UserEntity userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
                UserModel userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
                StudentModel studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.FullName, studentEntity.Group, studentEntity.Hobby);
                studentModels.Add(studentModel);
            }
            return studentModels;
        }

        public StudentModel GetById(int Id)
        {
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
            var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
            var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.FullName, studentEntity.Group, studentEntity.Hobby);
            return studentModel;
        }

        public void Update(int Id, StudentModel studentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentModel.User.Id).FirstOrDefault();
                var newStudentEntity = new StudentEntity(Id, userEntity, studentModel.FullName, studentModel.Group, studentModel.Hobby);
                uof.Update<StudentEntity>(newStudentEntity);
                uof.SaveChanges();
            }
        }
    }
}
