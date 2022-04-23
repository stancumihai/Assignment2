using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class ProfessorService : IProfessorService
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public ProfessorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Add(ProfessorModel t)
        {
           using(UnitOfWork)
            {

            }
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ProfessorModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ProfessorModel> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public ProfessorModel GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProfessorModel t)
        {
            throw new NotImplementedException();
        }

        public void Update(long Id, ProfessorModel t)
        {
            throw new NotImplementedException();
        }
    }
}
