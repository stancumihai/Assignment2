using DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<ProfessorEntity> ProfessorEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<LaboratoryEntity> LaboratoryEntities { get; set; }
        public DbSet<AssignmentEntity> AssignmentEntities { get; set; }
        public DbSet<StudentAssigmentsEntity> StudentAssigmentsEntities { get; set; }
        public DbSet<ProfessorLaboratoriesEntity> ProfessorLaboratoriesEntities { get; set; }
        public DbSet<StudentLaboratoriesEntity> StudentLaboratoriesEntities { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
     : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=.;Database=SchoolDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAssigmentsEntity>()
                .HasOne(s => s.Student)
                .WithMany(sa => sa.StudentAssigments)
                .HasForeignKey(si => si.StudentId);

            modelBuilder.Entity<StudentAssigmentsEntity>()
                .HasOne(a => a.Assignment)
                .WithMany(sa => sa.StudentAssigments)
                .HasForeignKey(ai => ai.AssignmentId);
        }
    }
}
