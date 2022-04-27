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
    public class AssignmentService : IAssignmentService
    {
        private readonly IGenericRepository GenericRepository;
        private IMapper Mapper;
        public AssignmentService(IGenericRepository genericRepository, IMapper Mapper)
        {
            this.Mapper = Mapper;
            GenericRepository = genericRepository;
        }

        public void Add(AssignmentModel assignmentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentModel.Laboratory.Id).FirstOrDefault();
            var assignmentEntity = Mapper.Map<AssignmentEntity>(assignmentModel);
            assignmentEntity.Laboratory = null;
            assignmentEntity.LaboratoryId = assignmentModel.Laboratory.Id;
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
                LaboratoryModel laboratoryModel = Mapper.Map<LaboratoryModel>(laboratoryEntity);
                AssignmentModel assignmentModel = Mapper.Map<AssignmentModel>(assignmentEntity);
                assignmentModel.Laboratory = laboratoryModel;
                assignmentModels.Add(assignmentModel);
            }
            return assignmentModels;
        }

        public AssignmentModel GetById(int Id)
        {
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentEntity.LaboratoryId).FirstOrDefault();
            var laboratoryModel = Mapper.Map<LaboratoryModel>(laboratoryEntity);
            AssignmentModel assignmentModel = Mapper.Map<AssignmentModel>(assignmentEntity);
            assignmentModel.Laboratory = laboratoryModel;
            return assignmentModel;
        }

        public void Update(int Id, AssignmentModel assignmentModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            if (assignmentEntity != null)
            {
                var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(laboratory => laboratory.Id == assignmentModel.Laboratory.Id).FirstOrDefault();
                var newAssignmentEntity = Mapper.Map<AssignmentEntity>(assignmentModel);
                newAssignmentEntity.Id = Id;
                newAssignmentEntity.Laboratory = laboratoryEntity;
                uof.Update<AssignmentEntity>(newAssignmentEntity);
                uof.SaveChanges();
            }
        }
    }
}
