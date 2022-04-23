using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        protected readonly SchoolDbContext Context;


        public GenericRepository(SchoolDbContext Context)
        {
            this.Context = Context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            
            //return new UnitOfWork();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(long id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }


        public void Update(TEntity entity)
        {
            Context.ChangeTracker.Clear();
            Context.Set<TEntity>().Update(entity);
        }
    }
}
