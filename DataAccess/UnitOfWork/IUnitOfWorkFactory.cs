using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
