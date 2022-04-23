using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class AssignmentRepository : GenericRepository<AssignmentEntity> , IAssignmentRepository
    {

        public AssignmentRepository(SchoolDbContext Context) : base(Context)
        {

        }
    }
}
