using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ProfessorRepository : GenericRepository<ProfessorEntity> , IProfessorRepository
    {
        public ProfessorRepository(SchoolDbContext Context) : base(Context)
        {

        }
    }
}
