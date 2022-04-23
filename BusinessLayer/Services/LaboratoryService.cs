using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using DataAccess.UnitOfWorkLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Add(LaboratoryModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var labEntity = Mapper.Map<LaboratoryEntity>(t);
            uof.Add<LaboratoryEntity>(labEntity);
            uof.SaveChanges();
        }

        public void Delete(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var labEntity = uof.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (labEntity != null)
            {
                uof.Delete<LaboratoryEntity>(labEntity);
                uof.SaveChanges();
            }
        }

        public List<LaboratoryModel> GetAll()
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var labEntities = uof.Get<LaboratoryEntity>();
            var labModels = Mapper.Map<List<LaboratoryModel>>(labEntities);
            return labModels;
        }

        public LaboratoryModel GetById(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var labEntity = uof.Get<LaboratoryEntity>().Where(user => user.Id == Id).FirstOrDefault();
            return Mapper.Map<LaboratoryModel>(labEntity);
        }

        public void Update(long Id, LaboratoryModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var labEntity = uof.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (labEntity != null)
            {
                var newLabEntity = Mapper.Map<LaboratoryEntity>(t);
                t.Id = Id;
                uof.Update<LaboratoryEntity>(newLabEntity);
                uof.SaveChanges();
            }
        }
    }
}
