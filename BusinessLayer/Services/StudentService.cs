using AutoMapper;
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
        private readonly IMapper Mapper;

        public StudentService(IGenericRepository genericRepository, IMapper Mapper)
        {
            GenericRepository = genericRepository;
            this.Mapper = Mapper;
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
                UserModel userModel = Mapper.Map<UserModel>(userEntity);
                StudentModel studentModel = Mapper.Map<StudentModel>(studentEntity);
                studentModel.User = userModel;
                studentModels.Add(studentModel);
            }
            return studentModels;
        }

        public StudentModel GetById(int Id)
        {
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
            var userModel = Mapper.Map<UserModel>(userEntity);
            var studentModel = Mapper.Map<StudentModel>(studentEntity);
            studentModel.User = userModel;
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

        public List<SubmissionModel> GetSubmissionsByStudentId(int Id)
        {
            var submissionEntities = GenericRepository.Get<SubmissionEntity>().ToList();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            var studentSubmissions = new List<SubmissionModel>();
            if (studentEntity != null)
            {
                foreach (var submissionEntity in submissionEntities)
                {
                    if (submissionEntity.StudentId == Id)
                    {
                        var studentSubmissionModel = Mapper.Map<SubmissionModel>(submissionEntity);
                        studentSubmissionModel.Student = Mapper.Map<StudentModel>(studentEntity);
                        studentSubmissions.Add(studentSubmissionModel);
                    }
                }
                return studentSubmissions;
            }
            return null;
        }

        public List<AssignmentModel> GetAssignmentsByStudentId(int Id)
        {
            return null;
        }

        public List<LaboratoryModel> GetLaboratoriesByStudentId(int Id)
        {
            var studentLaboratoriesEntities = GenericRepository.Get<StudentLaboratoriesEntity>().ToList();
            var labsOfStudentLaboratories = new List<LaboratoryModel>();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                foreach (var studentLaboratoriesEntity in studentLaboratoriesEntities)
                {
                    if (studentLaboratoriesEntity.StudentId == Id)
                    {
                        var labEntity = studentLaboratoriesEntity.Laboratory;
                        var labModel = Mapper.Map<LaboratoryModel>(labEntity);
                        labsOfStudentLaboratories.Add(labModel);
                    }
                }
                return labsOfStudentLaboratories;
            }
            return null;
        }
    }
}
