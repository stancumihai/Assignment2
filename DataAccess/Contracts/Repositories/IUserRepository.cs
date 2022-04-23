using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
    }
}
