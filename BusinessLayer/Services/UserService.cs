using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Contracts.Models;
using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository GenericRepository;
        private IMapper Mapper;
        public UserService(IGenericRepository GenericRepository, IMapper Mapper)
        {
            this.GenericRepository = GenericRepository;
            this.Mapper = Mapper;
        }

        public void Add(UserModel userModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = Mapper.Map<UserEntity>(userModel);
            uof.Add<UserEntity>(userEntity);
            uof.SaveChanges();
        }

        public void Delete(int Id)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            if (userEntity != null)
            {
                uof.Delete<UserEntity>(userEntity);
                uof.SaveChanges();
            }
        }

        public List<UserModel> GetAll()
        {
            var userEntities = GenericRepository.Get<UserEntity>();
            var userModels = new List<UserModel>();
            foreach (var userEntity in userEntities)
            {
                var userModel = Mapper.Map<UserModel>(userEntity);
                userModels.Add(userModel);
            }
            return userModels;
        }

        public UserModel GetById(int Id)
        {
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            var userModel = Mapper.Map<UserModel>(userEntity);
            return userModel;
        }

        public void Update(int Id, UserModel userModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            if (userEntity != null)
            {
                var newUserEntity = Mapper.Map<UserEntity>(userModel);
                newUserEntity.Id = Id;
                uof.Update<UserEntity>(newUserEntity);
                uof.SaveChanges();
            }
        }
    }
}
