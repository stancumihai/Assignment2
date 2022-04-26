using DataAccess.Contracts;
using DataAccess.UnitOfWorkLogic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly SchoolDbContext context;

        public GenericRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public IUnitOfWork CreateUnitOFWork()
        {
            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory(context);
            return unitOfWorkFactory.CreateUnitOfWork();
        }

        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(context);
        }

        protected SchoolDbContext Context
        {
            get { return this.context; }
        }
    }
}
