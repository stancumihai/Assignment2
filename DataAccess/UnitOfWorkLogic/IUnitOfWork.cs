using DataAccess.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.UnitOfWorkLogic
{
    public interface IUnitOfWork : IGenericRepository
    {
        IQueryable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class;
        public void Add<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void SaveChanges();
    }
}
