using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IGenericRepository GenericRepository;

        public SubmissionService(IGenericRepository GenericRepository)
        {
            this.GenericRepository = GenericRepository;
        }

        public void Add(SubmissionModel submissionModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionModel.Assignment.Id).FirstOrDefault();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionModel.Student.Id).FirstOrDefault();
            var submissionEntity = new SubmissionEntity(submissionModel.Id, null, submissionModel.Assignment.Id, null, submissionModel.Student.Id, submissionModel.Github, submissionModel.Comment);
            uof.Add<SubmissionEntity>(submissionEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == Id).FirstOrDefault();
            if (submissionEntity != null)
            {
                uof.Delete<SubmissionEntity>(submissionEntity);
                uof.SaveChanges();
            }
        }

        public List<SubmissionModel> GetAll()
        {
            var submissionEntities = GenericRepository.Get<SubmissionEntity>().ToList();
            var submissionModels = new List<SubmissionModel>();
            foreach (var submissionEntity in submissionEntities)
            {
                var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionEntity.AssignmentId).FirstOrDefault();
                var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionEntity.StudentId).FirstOrDefault();
                var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
                var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();

                var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
                var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
                var assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);
                var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.Group, studentEntity.FullName, studentEntity.Hobby);
                
                var submissionModel = new SubmissionModel(submissionEntity.Id, assignmentModel, studentModel, submissionEntity.Github, submissionEntity.Comment);

                submissionModels.Add(submissionModel);
            }
            return submissionModels;
        }

        public SubmissionModel GetById(int Id)
        {
            var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == Id).FirstOrDefault();

            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionEntity.AssignmentId).FirstOrDefault();
            var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionEntity.StudentId).FirstOrDefault();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == studentEntity.UserId).FirstOrDefault();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();

            var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
            var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
            var assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);
            var studentModel = new StudentModel(studentEntity.Id, userModel, studentEntity.Group, studentEntity.FullName, studentEntity.Hobby);
            var submissionModel = new SubmissionModel(submissionEntity.Id, assignmentModel, studentModel, submissionEntity.Github, submissionEntity.Comment);

            return submissionModel;
        }

        public void Update(int Id, SubmissionModel submissionModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var submissionEntity = GenericRepository.Get<SubmissionEntity>().Where(submission => submission.Id == Id).FirstOrDefault();
            if (submissionEntity != null)
            {
                var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assignment => assignment.Id == submissionModel.Assignment.Id).FirstOrDefault();
                var studentEntity = GenericRepository.Get<StudentEntity>().Where(student => student.Id == submissionModel.Student.Id).FirstOrDefault();
                var newSubmissionEntity = new SubmissionEntity(Id, assignmentEntity, studentEntity, submissionModel.Github, submissionModel.Comment);
                uof.Update<SubmissionEntity>(newSubmissionEntity);
                uof.SaveChanges();
            }
        }
    }
}
