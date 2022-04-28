using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
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
            else throw new Exception();
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
            if (studentEntity == null)
            {
                throw new Exception();
            }

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
            else throw new Exception();
        }

        public List<SubmissionModel> GetSubmissionsByStudentId(int Id)
        {
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                List<SubmissionEntity> submissionEntities = GenericRepository.Get<SubmissionEntity>()
                                        .Where(submission => submission.StudentId == Id).ToList();
                List<SubmissionModel> submissionModels = Mapper.Map<List<SubmissionModel>>(submissionEntities);

                foreach (var submissionModel in submissionModels)
                {
                    submissionModel.Student = Mapper.Map<StudentModel>(studentEntity);
                }
                return submissionModels;
            }
            else throw new Exception();
        }

        public List<AssignmentModel> GetAssignmentsByStudentId(int Id)
        {
            List<AssignmentEntity> asd = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.LaboratoryId == Id).ToList();
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
                    var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>()
                        .Where(laboratory => laboratory.Id == studentLaboratoriesEntity.LaboratoryId).FirstOrDefault();

                    var studentEntity1 = GenericRepository.Get<StudentEntity>()
                        .Where(student => student.Id == studentLaboratoriesEntity.StudentId).FirstOrDefault();
                    studentLaboratoriesEntity.Student = studentEntity1;
                    studentLaboratoriesEntity.Laboratory = laboratoryEntity;
                    if (studentLaboratoriesEntity.StudentId == Id)
                    {
                        var labEntity = studentLaboratoriesEntity.Laboratory;
                        var labModel = Mapper.Map<LaboratoryModel>(labEntity);
                        labsOfStudentLaboratories.Add(labModel);
                    }
                }
                return labsOfStudentLaboratories;
            }
            else throw new Exception();
        }


        public List<GradingModel> GetGradingsByStudentId(int Id)
        {

            List<SubmissionModel> submissionModels = GetSubmissionsByStudentId(Id);
            List<GradingEntity> gradingEntities = GenericRepository.Get<GradingEntity>().ToList();
            List<GradingModel> gradingModels = new List<GradingModel>();
            var gradingSubmissionEntites = new List<GradingEntity>();
            foreach (var submissionModel in submissionModels)
            {
                var gradingSubmissionEntity = gradingEntities.Where(x => x.SubmissionId == submissionModel.Id).FirstOrDefault();
                gradingSubmissionEntites.Add(gradingSubmissionEntity);
            }

            return Mapper.Map<List<GradingModel>>(gradingSubmissionEntites);
        }

        public FinalResultModel GetFinalResultByStudentId(int Id)
        {
            List<GradingModel> gradingModels = GetGradingsByStudentId(Id);

            float sum = 0;
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            var studentModel = Mapper.Map<StudentModel>(studentEntity);
            var resultModel = new FinalResultModel
            {
                Student = studentModel,
            };

            foreach (var gradingModel in gradingModels)
            {
                if (gradingModel.Grade < 5)
                {
                    resultModel.Status = "Failed";
                    return resultModel;
                }

                sum += gradingModel.Grade;
            }

            int gradingCnt = gradingModels.Count;
            float average = sum / (float)gradingCnt;
            if (average >= 6)
            {
                resultModel.Status = "Passed";
                return resultModel;
            }
            else
            {
                resultModel.Status = "Failed";
                return resultModel;
            }
        }
    }
}
