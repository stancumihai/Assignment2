using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IGenericRepository GenericRepository;

        public AssignmentService(IGenericRepository genericRepository)
        {
            GenericRepository = genericRepository;
        }

        public void Add(AssignmentModel assignmentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentModel.Laboratory.Id).FirstOrDefault();
            var assignmentEntity = new AssignmentEntity(assignmentModel.Id, null, assignmentModel.Laboratory.Id, assignmentModel.DeadLine, assignmentModel.Description);
            uof.Add<AssignmentEntity>(assignmentEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            if (assignmentEntity != null)
            {
                uof.Delete<AssignmentEntity>(assignmentEntity);
                uof.SaveChanges();
            }
        }

        public List<AssignmentModel> GetAll()
        {
            var assignmentEntities = GenericRepository.Get<AssignmentEntity>().ToList();
            var assignmentModels = new List<AssignmentModel>();
            foreach (var assignmentEntity in assignmentEntities)
            {
                LaboratoryEntity laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();
                LaboratoryModel laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
                AssignmentModel assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);
                assignmentModels.Add(assignmentModel);

            }
            return assignmentModels;
        }

        public AssignmentModel GetById(int Id)
        {
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();
            var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
            var assignmentModel = new AssignmentModel(assignmentEntity.Id, laboratoryModel, assignmentEntity.DeadLine, assignmentEntity.Description);

            return assignmentModel;
        }

        public void Update(int Id, AssignmentModel assignmentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            if (assignmentEntity != null)
            {
                var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentModel.Laboratory.Id).FirstOrDefault();
                var newAssignmentEntity = new AssignmentEntity(Id, laboratoryEntity, assignmentModel.DeadLine, assignmentModel.Description);
                uof.Update<AssignmentEntity>(newAssignmentEntity);
                uof.SaveChanges();
            }
        }
    }
}
