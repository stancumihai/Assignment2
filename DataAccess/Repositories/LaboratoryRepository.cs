using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class LaboratoryRepository : GenericRepository<LaboratoryEntity> , ILaboratoryRepository
    {
        public LaboratoryRepository(SchoolDbContext Context) : base(Context)
        {

        }
    }
}
