using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IGenericRepository<AssignmentEntity> GenericRepository;
        //inject unit of work
        private readonly IMapper Mapper;
        public AssignmentService(IUnitOfWork UnitOfWork, IMapper Mapper, IGenericRepository<AssignmentEntity> GenericRepository)
        {
            this.UnitOfWork = UnitOfWork;
            this.Mapper = Mapper;
            this.GenericRepository = GenericRepository;
        }

        public void Add(AssignmentModel assignment)
        {

            using (UnitOfWork)
            {
                var assignmentEntity = Mapper.Map<AssignmentEntity>(assignment);
                UnitOfWork.AssigmentRepository.Add(assignmentEntity);
            }
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<AssignmentModel> GetAll()
        {
            using (UnitOfWork)
            {
                List<AssignmentEntity> allAssignments = UnitOfWork.AssigmentRepository.GetAll().ToList();
                UnitOfWork.Complete();
                return Mapper.Map<List<AssignmentModel>>(allAssignments);
            }
        }

        public List<AssignmentModel> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public AssignmentModel GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssignmentModel t)
        {
            throw new NotImplementedException();
        }

        public void Update(long Id, AssignmentModel t)
        {
            throw new NotImplementedException();
        }
    }
}
