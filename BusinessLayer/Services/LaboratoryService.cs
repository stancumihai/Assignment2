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
            else throw new Exception();
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
            if (laboratoryEntity == null) throw new Exception();

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
            else throw new Exception();
        }


        public List<AssignmentModel> GetAssignmentsByLaboratoryId(long Id)
        {
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (laboratoryEntity != null)
            {
                List<AssignmentEntity> assignmentEntities = GenericRepository.Get<AssignmentEntity>().Where(assign => assign.LaboratoryId == Id).ToList();
                List<AssignmentModel> assignmentModels = Mapper.Map<List<AssignmentModel>>(assignmentEntities);
                foreach (var model in assignmentModels)
                {
                    model.Laboratory = Mapper.Map<LaboratoryModel>(laboratoryEntity);
                }
                return assignmentModels;
            }
            else throw new Exception();
        }
    }
}
