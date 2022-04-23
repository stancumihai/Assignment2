using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new DatabaseContext());
        }
    }
}
