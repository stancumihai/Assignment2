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
    public class AssignmentService : IAssignmentService
    {
        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;

        public AssignmentService(IGenericRepository genericRepository, IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }

        public void Add(AssignmentModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            uof.Add<AssignmentEntity>(Mapper.Map<AssignmentEntity>(t));
            uof.SaveChanges();
        }

        public void Delete(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = uof.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            if (assignmentEntity != null)
            {
                uof.Delete<AssignmentEntity>(assignmentEntity);
                uof.SaveChanges();
            }
        }

        public List<AssignmentModel> GetAll()
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntities = uof.Get<AssignmentEntity>();
            var assignmentModels = Mapper.Map<List<AssignmentModel>>(assignmentEntities);
            return assignmentModels;
        }

        public AssignmentModel GetById(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = uof.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            return Mapper.Map<AssignmentModel>(assignmentEntity);
        }

        public void Update(long Id, AssignmentModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var assignmentEntity = uof.Get<AssignmentEntity>().Where(assign => assign.Id == Id).FirstOrDefault();
            if (assignmentEntity != null)
            {
                var newAssignmentEntity = Mapper.Map<AssignmentEntity>(t);
                t.Id = Id;
                uof.Update<AssignmentEntity>(newAssignmentEntity);
                uof.SaveChanges();
            }
        }
    }
}
