/*using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SchoolDbContext Context;

        public UnitOfWork(SchoolDbContext context,
            IAssignmentRepository assigmentRepository,
            ILaboratoryRepository laboratoryRepository,
            IProfessorRepository professorRepository,
            IStudentRepository studentRepository,
            IUserRepository userRepository)
        {
            Context = context;
            AssigmentRepository = assigmentRepository;
            LaboratoryRepository = laboratoryRepository;
            ProfessorRepository = professorRepository;
            StudentRepository = studentRepository;
            UserRepository = userRepository;
        }

        public IAssignmentRepository AssigmentRepository { get; private set; }
        public ILaboratoryRepository LaboratoryRepository { get; private set; }
        public IProfessorRepository ProfessorRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

       

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
*/