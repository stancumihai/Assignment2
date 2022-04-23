using DataAccess.Contracts;
using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class StudentRepository : GenericRepository<StudentEntity> , IStudentRepository
    {
        public StudentRepository(SchoolDbContext Context) : base(Context)
        {

        }
    }
}
