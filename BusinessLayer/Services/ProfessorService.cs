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
    public class ProfessorService : IProfessorService
    {
        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;

        public ProfessorService(IGenericRepository genericRepository, IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }

        public void Add(ProfessorModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var professorEntity = Mapper.Map<ProfessorEntity>(t);
            uof.Add<ProfessorEntity>(professorEntity);
            uof.SaveChanges();
        }

        public void Delete(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var professorEntity = uof.Get<ProfessorEntity>().Where(professor => professor.Id == Id).FirstOrDefault();
            if (professorEntity != null)
            {
                uof.Delete<ProfessorEntity>(professorEntity);
                uof.SaveChanges();
            }
        }

        public List<ProfessorModel> GetAll()
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var professorEntities = uof.Get<ProfessorEntity>();
            var professorModels = Mapper.Map<List<ProfessorModel>>(professorEntities);
            uof.SaveChanges();
            return professorModels;
        }
        public ProfessorModel GetById(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var professorEntity = uof.Get<ProfessorEntity>().Where(professor => professor.Id == Id).FirstOrDefault();
            var professorModel = Mapper.Map<ProfessorModel>(professorEntity);
            return professorModel;
        }

        public void Update(long Id, ProfessorModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var professorEntity = uof.Get<ProfessorEntity>().Where(professor => professor.Id == Id).FirstOrDefault();
            if (professorEntity != null)
            {
                var newProfessorEntity = Mapper.Map<ProfessorEntity>(t);
                t.Id = Id;
                uof.Update<ProfessorEntity>(newProfessorEntity);
                uof.SaveChanges();
            }
        }
    }
}
