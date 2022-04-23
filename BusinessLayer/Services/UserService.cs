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
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;
        private ILogger Logger;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILoggerFactory Logger)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            this.Logger = Logger.CreateLogger("UserServiceLogger");
        }

        public void Add(UserModel User)
        {
            using (UnitOfWork)
            {
                var userEntity = Mapper.Map<UserEntity>(User);
                UnitOfWork.UserRepository.Add(userEntity);
                Logger.LogInformation(userEntity.ToString());
                UnitOfWork.Complete();
            }
        }

        public void Delete(long Id)
        {
            using (UnitOfWork)
            {
                var userEntity = UnitOfWork.UserRepository.Get(Id);
                if (userEntity != null)
                {
                    UnitOfWork.UserRepository.Remove(userEntity);
                    UnitOfWork.Complete();
                }
            }
        }

        public List<UserModel> GetAll()
        {
            using (UnitOfWork)
            {
                List<UserEntity> allUsers = UnitOfWork.UserRepository.GetAll().ToList();
                return Mapper.Map<List<UserModel>>(allUsers);
            }
        }

        public List<UserModel> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(long Id)
        {
            var userEntity = UnitOfWork.UserRepository.Get(Id);
            return Mapper.Map<UserModel>(userEntity);
        }


        public void Update(long Id, UserModel t)
        {
            using (UnitOfWork)
            {
                var userToUpdate = UnitOfWork.UserRepository.Get(Id);
                Logger.LogInformation("userToUpdate:" + userToUpdate.ToString());
                if (userToUpdate != null)
                {
                    var userEntity = Mapper.Map<UserEntity>(t);
                    userEntity.Id = Id;
                    Logger.LogInformation("userEntity:" + userEntity.ToString());
                    UnitOfWork.UserRepository.Update(userEntity);
                }
            }
        }
    }
}
