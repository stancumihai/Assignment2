using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IGenericRepository GenericRepository;

        public LaboratoryService(IGenericRepository GenericRepository)
        {
            this.GenericRepository = GenericRepository;

        }

        public void Add(LaboratoryModel laboratoryModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var labEntity = new LaboratoryEntity(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description);
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
                var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
                laboratoryModels.Add(laboratoryModel);
            }
            return laboratoryModels;
        }

        public LaboratoryModel GetById(int Id)
        {
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(user => user.Id == Id).FirstOrDefault();
            var laboratoryModel = new LaboratoryModel(laboratoryEntity.Id, laboratoryEntity.LaboratoryNumber, laboratoryEntity.Date, laboratoryEntity.Title, laboratoryEntity.Objectives, laboratoryEntity.Description);
            return laboratoryModel;
        }

        public void Update(int Id, LaboratoryModel laboratoryModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>().Where(lab => lab.Id == Id).FirstOrDefault();
            if (laboratoryEntity != null)
            {
                var newLabEntity = new LaboratoryEntity(laboratoryModel.Id, laboratoryModel.LaboratoryNumber, laboratoryModel.Date, laboratoryModel.Title, laboratoryModel.Objectives, laboratoryModel.Description);
                uof.Update<LaboratoryEntity>(newLabEntity);
                uof.SaveChanges();
            }
        }
    }
}
