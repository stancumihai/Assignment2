using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class GradingService : IGradingService
    {
        public IGenericRepository GenericRepository;

        public GradingService(IGenericRepository genericRepository)
        {
            GenericRepository = genericRepository;
        }

        public void Add(GradingModel gradingModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == gradingModel.Submission.Id).FirstOrDefault();
            var gradingEntity = new GradingEntity(gradingModel.Id, null, gradingModel.Submission.Id, gradingModel.Grade);
            uof.Add<GradingEntity>(gradingEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var gradingEntity = GenericRepository.Get<GradingEntity>().Where(grading => grading.Id == Id).FirstOrDefault();
            if (gradingEntity != null)
            {
                uof.Delete<GradingEntity>(gradingEntity);
                uof.SaveChanges();
            }
            else throw new Exception();
        }

        public List<GradingModel> GetAll()
        {
            var gradingEntities = GenericRepository.Get<GradingEntity>().ToList();
            var gradindModels = new List<GradingModel>();
            foreach (var gradingEntity in gradingEntities)
            {
                var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == gradingEntity.SubmissionId).FirstOrDefault();
                var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionEntity.AssignmentId).FirstOrDefault();
                var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionEntity.StudentId).FirstOrDefault();
                var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
                var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();

                var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
                var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.FullName, studentEntity.Group, studentEntity.Hobby);
                var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
                var assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);
                var submissionModel = new SubmissionModel(submissionEntity.Id, assignmentModel, studentModel, submissionEntity.Github, submissionEntity.Comment);
                var gradingModel = new GradingModel(gradingEntity.Id, submissionModel, gradingEntity.Grade);
                gradindModels.Add(gradingModel);
            }
            return gradindModels;
        }

        public GradingModel GetById(int Id)
        {
            var gradingEntity = GenericRepository.Get<GradingEntity>().Where(grading => grading.Id == Id).FirstOrDefault();
            if (gradingEntity == null) throw new Exception();

            var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == gradingEntity.SubmissionId).FirstOrDefault();
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionEntity.AssignmentId).FirstOrDefault();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionEntity.StudentId).FirstOrDefault();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();


            var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
            var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.FullName, studentEntity.Group, studentEntity.Hobby);
            var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
            var assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);
            var submissionModel = new SubmissionModel(submissionEntity.Id, assignmentModel, studentModel, submissionEntity.Github, submissionEntity.Comment);

            var gradingModel = new GradingModel(gradingEntity.Id, submissionModel, gradingEntity.Grade);

            return gradingModel;
        }

        public void Update(int Id, GradingModel gradingModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var gradingEntity = GenericRepository.Get<GradingEntity>().Where(grading => grading.Id == Id).FirstOrDefault();
            if (gradingEntity != null)
            {
                var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == gradingEntity.Submission.Id).FirstOrDefault();
                var newGradingEntity = new GradingEntity(Id, submissionEntity, gradingModel.Grade);
                uof.Update<GradingEntity>(newGradingEntity);
                uof.SaveChanges();
            }
            else throw new Exception();
        }
    }
}
