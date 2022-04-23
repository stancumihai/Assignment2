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
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository GenericRepository;
        private readonly IMapper Mapper;
        public UserService(IGenericRepository GenericRepository, IMapper Mapper)
        {
            this.GenericRepository = GenericRepository;
            this.Mapper = Mapper;
        }

        public void Add(UserModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var userEntity = Mapper.Map<UserEntity>(t);
            uof.Add<UserEntity>(userEntity);
            uof.SaveChanges();
        }

        public void Delete(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var userEntity = uof.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            if (userEntity != null)
            {
                uof.Delete<UserEntity>(userEntity);
            }
            uof.SaveChanges();
        }

        public List<UserModel> GetAll()
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var userEntities = uof.Get<UserEntity>();
            var userModels = Mapper.Map<List<UserModel>>(userEntities);
            uof.SaveChanges();
            return userModels;
        }

        public UserModel GetById(long Id)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var userEntity = uof.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            return Mapper.Map<UserModel>(userEntity);
        }

        public void Update(long Id, UserModel t)
        {
            IUnitOfWork uof = GenericRepository.CreateUnitOfWork();
            var userEntity = uof.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            if (userEntity != null)
            {
                var newUserEntity = Mapper.Map<UserEntity>(t);
                t.Id = Id;
                uof.Update<UserEntity>(newUserEntity);
                uof.SaveChanges();
            }
        }
    }
}
