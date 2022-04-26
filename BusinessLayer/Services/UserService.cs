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
        public UserService(IGenericRepository GenericRepository)
        {
            this.GenericRepository = GenericRepository;
        }

        public void Add(UserModel userModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = new UserEntity(userModel.Id, userModel.Email, userModel.Password);
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
                var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
                userModels.Add(userModel);
            }
            return userModels;
        }

        public UserModel GetById(int Id)
        {
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            var userModel = new UserModel(userEntity.Id, userEntity.Email, userEntity.Password);
            return userModel;
        }

        public void Update(int Id, UserModel userModel)
        {
            using var uof = GenericRepository.CreateUnitOfWork();
            var userEntity = GenericRepository.Get<UserEntity>().Where(user => user.Id == Id).FirstOrDefault();
            if (userEntity != null)
            {
                var newUserEntity = new UserEntity(userModel.Id, userModel.Email, userModel.Password)
                {
                    Id = Id
                };
                uof.Update<UserEntity>(newUserEntity);
                uof.SaveChanges();
            }
        }
    }
}
