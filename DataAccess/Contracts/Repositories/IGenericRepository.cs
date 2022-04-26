using DataAccess.UnitOfWorkLogic;
using System.Linq;

namespace DataAccess.Contracts
{
    public interface IGenericRepository : IUnitOfWorkFactory
    {
        IQueryable<T> Get<T>() where T : class, IEntity;
    }
}
