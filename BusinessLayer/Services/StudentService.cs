using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using DataAccess.UnitOfWorkLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;

        public StudentService(IGenericRepository genericRepository, IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }

        public void Add(StudentModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = Mapper.Map<StudentEntity>(t);
            uof.Add<StudentEntity>(studentEntity);
            uof.SaveChanges();
        }

        public void Delete(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = uof.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                uof.Delete<StudentEntity>(studentEntity);
                uof.SaveChanges();
            }
        }

        public List<StudentModel> GetAll()
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var studentEntities = uof.Get<StudentEntity>();
            var studentModels = Mapper.Map<List<StudentModel>>(studentEntities);
            uof.SaveChanges();
            return studentModels;
        }

        public StudentModel GetById(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = uof.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            return Mapper.Map<StudentModel>(studentEntity);
        }

        public void Update(long Id, StudentModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var studentEntity = uof.Get<StudentEntity>().Where(student => student.Id == Id).FirstOrDefault();
            if (studentEntity != null)
            {
                t.Id = Id;
                uof.Update(t);
                uof.SaveChanges();
            }
        }
    }
}
