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
    public class StudentLaboratoriesService : IStudentLaboratoriesService
    {

        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;

        public StudentLaboratoriesService(IGenericRepository genericRepository, IMapper mapper)
        {
            GenericRepository = genericRepository;
            Mapper = mapper;
        }

        public void Add(StudentLaboratoriesModel studentLaboratoriesModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();

            var studentEntity = GenericRepository.Get<StudentEntity>()
                .Where(student => student.Id == studentLaboratoriesModel.Student.Id).FirstOrDefault();

            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>()
                .Where(laboratory => laboratory.Id == studentLaboratoriesModel.Laboratory.Id).FirstOrDefault();

            var studentLaboratoryEntity = new StudentLaboratoriesEntity
            {
                Id = studentLaboratoriesModel.Id,
                Laboratory = null,
                LaboratoryId = studentLaboratoriesModel.Laboratory.Id,
                Student = null,
                StudentId = studentLaboratoriesModel.Student.Id
            };

            uof.Add<StudentLaboratoriesEntity>(studentLaboratoryEntity);
            uof.SaveChanges();


        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var studentLaboratoryEntity = GenericRepository.Get<StudentLaboratoriesEntity>()
               .Where(studentLaboratory => studentLaboratory.Id == Id).FirstOrDefault();

            if (studentLaboratoryEntity == null)
            {
                throw new Exception();
            }
            uof.Delete<StudentLaboratoriesEntity>(studentLaboratoryEntity);
            uof.SaveChanges();
        }

        public List<StudentLaboratoriesModel> GetAll()
        {
            var studentLaboratoryEntities = GenericRepository.Get<StudentLaboratoriesEntity>().ToList();
            var studentLaboratoryModels = new List<StudentLaboratoriesModel>();
            foreach (var studentLaboratoryEntity in studentLaboratoryEntities)
            {
                var studentEntity = GenericRepository.Get<StudentEntity>()
                    .Where(student => student.Id == studentLaboratoryEntity.StudentId).FirstOrDefault();

                var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>()
                    .Where(laboratory => laboratory.Id == studentLaboratoryEntity.LaboratoryId).FirstOrDefault();

                var studentLaboratoryModel = new StudentLaboratoriesModel
                {
                    Id = studentLaboratoryEntity.Id,
                    Student = Mapper.Map<StudentModel>(studentEntity),
                    Laboratory = Mapper.Map<LaboratoryModel>(laboratoryEntity)
                };
                studentLaboratoryModels.Add(studentLaboratoryModel);
            }
            return studentLaboratoryModels;
        }

        public StudentLaboratoriesModel GetById(int Id)
        {
            var studentLaboratoryEntity = GenericRepository.Get<StudentLaboratoriesEntity>()
                  .Where(studentLaboratory => studentLaboratory.Id == Id).FirstOrDefault();

            if (studentLaboratoryEntity == null)
            {
                throw new Exception();
            }

            var studentEntity = GenericRepository.Get<StudentEntity>()
                   .Where(student => student.Id == studentLaboratoryEntity.StudentId).FirstOrDefault();

            var laboratoryEntity = GenericRepository.Get<LaboratoryEntity>()
                .Where(laboratory => laboratory.Id == studentLaboratoryEntity.LaboratoryId).FirstOrDefault();

            var studentLaboratoryModel = new StudentLaboratoriesModel
            {
                Id = studentLaboratoryEntity.Id,
                Student = Mapper.Map<StudentModel>(studentEntity),
                Laboratory = Mapper.Map<LaboratoryModel>(laboratoryEntity)
            };

            return studentLaboratoryModel;
        }

        public void Update(int Id, StudentLaboratoriesModel t)
        {
            throw new NotImplementedException();
        }
    }
}
