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
    public class StudentService : IStudentService
    {

        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;
        private ILogger Logger;
        public StudentService(IUnitOfWork UnitOfWork, IMapper Mapper, ILoggerFactory Logger)
        {
            this.UnitOfWork = UnitOfWork;
            this.Mapper = Mapper;
            this.Logger = Logger.CreateLogger("StudentServiceFactory");
        }

        public void Add(StudentModel t)
        {
            using (UnitOfWork)
            {
                var studentEntity = Mapper.Map<StudentEntity>(t);
                UnitOfWork.StudentRepository.Add(studentEntity);
                Logger.LogInformation(studentEntity.ToString());
                UnitOfWork.Complete();
            }
        }

        public void Delete(long Id)
        {

        }

        public List<StudentModel> GetAll()
        {
            using (UnitOfWork)
            {
                var studentEntities = UnitOfWork.LaboratoryRepository.GetAll().ToList();
                return Mapper.Map<List<StudentModel>>(studentEntities);
            }
        }

        public List<StudentModel> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public StudentModel GetById(long Id)
        {
            using (UnitOfWork)
            {
                var studentEntity = UnitOfWork.StudentRepository.Get(Id);
                return Mapper.Map<StudentModel>(studentEntity);
            }
        }

        public void Update(StudentModel t)
        {
            throw new NotImplementedException();
        }

        public void Update(long Id, StudentModel t)
        {
            throw new NotImplementedException();
        }
    }
}
