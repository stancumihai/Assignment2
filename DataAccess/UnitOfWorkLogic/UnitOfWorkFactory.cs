namespace DataAccess.UnitOfWorkLogic
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly SchoolDbContext context;
        public UnitOfWorkFactory(SchoolDbContext context)
        {
            this.context = context;
        }
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(context);
        }
    }
}
