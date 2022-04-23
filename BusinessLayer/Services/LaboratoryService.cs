using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess;
using DataAccess.Contracts.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class LaboratoryService : ILaboratoryService
    {

        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;
        private ILogger Logger;

        public LaboratoryService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerFactory Logger)
        {
            this.Logger = Logger.CreateLogger("LaboratoryServiceLogger");
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Add(LaboratoryModel t)
        {
            using (UnitOfWork)
            {
                var labEntity = Mapper.Map<LaboratoryEntity>(t);
                UnitOfWork.LaboratoryRepository.Add(labEntity);
                UnitOfWork.Complete();
            }
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<LaboratoryModel> GetAll()
        {
            using (UnitOfWork)
            {
                var labEntities = UnitOfWork.LaboratoryRepository.GetAll().ToList();
                return Mapper.Map<List<LaboratoryModel>>(labEntities);
            }

        }

        public List<LaboratoryModel> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public LaboratoryModel GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Update(LaboratoryModel t)
        {
            throw new NotImplementedException();
        }

        public void Update(long Id, LaboratoryModel t)
        {
            throw new NotImplementedException();
        }
    }
}
