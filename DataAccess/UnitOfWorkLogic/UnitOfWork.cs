using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.UnitOfWorkLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext context;
        public UnitOfWork(SchoolDbContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Set<T>().Update(entity);
            
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return context.Set<T>().Where(expression);
        }
    }
}
