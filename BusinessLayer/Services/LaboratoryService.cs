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
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;
        public LaboratoryService(IGenericRepository GenericRepository, IMapper Mapper)
        {
            this.GenericRepository = GenericRepository;
            this.Mapper = Mapper;

        }

        public void Add(LaboratoryModel laboratoryModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var labEntity = Mapper.Map<LaboratoryEntity>(laboratoryModel);
            uof.Add<LaboratoryEntity>(labEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var labEntity = GenericRepository.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (labEntity != null)
            {
                uof.Delete<LaboratoryEntity>(labEntity);
                uof.SaveChanges();
            }
        }

        public List<LaboratoryModel> GetAll()
        {
            var labEntities = GenericRepository.Get<LaboratoryEntity>().ToList();
            var laboratoryModels = new List<LaboratoryModel>();
            foreach (var laboratoryEntity in labEntities)
            {
                var laboratoryModel = Mapper.Map<LaboratoryModel>(laboratoryEntity);
                laboratoryModels.Add(laboratoryModel);
            }
            return laboratoryModels;
        }

        public LaboratoryModel GetById(int Id)
        {
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(user => user.Id == Id).FirstOrDefault();
            var laboratoryModel = Mapper.Map<LaboratoryModel>(laboratoryEntity);
            return laboratoryModel;
        }

        public void Update(int Id, LaboratoryModel laboratoryModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (laboratoryEntity != null)
            {
                var newLabEntity = Mapper.Map<LaboratoryEntity>(laboratoryModel);
                newLabEntity.Id = Id;
                uof.Update<LaboratoryEntity>(newLabEntity);
                uof.SaveChanges();
            }
        }


        public List<AssignmentModel> GetAssignmentsByLaboratoryId(long Id)
        {
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            var assignmentEntities = GenericRepository.Get<AssignmentEntity>().ToList();
            var laboratoryAssignmentsModels = new List<AssignmentModel>();
            if (laboratoryEntity != null)
            {
                foreach (var assignmentEntity in assignmentEntities)
                {
                    if (assignmentEntity.LaboratoryId == laboratoryEntity.Id)
                    {
                        var laboratoryAssignmentModel = Mapper.Map<AssignmentModel>(assignmentEntity);
                        laboratoryAssignmentModel.Laboratory = Mapper.Map<LaboratoryModel>(laboratoryEntity);
                        laboratoryAssignmentsModels.Add(laboratoryAssignmentModel);
                    }
                }
            }
            return laboratoryAssignmentsModels;
        }
    }
}
