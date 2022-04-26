using DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<LaboratoryEntity> LaboratoryEntities { get; set; }
        public DbSet<AssignmentEntity> AssignmentEntities { get; set; }
        public DbSet<RoleEntity> RolesEntities { get; set; }
        public DbSet<StudentLaboratoriesEntity> StudentLaboratoriesEntities { get; set; }
        public DbSet<UserRolesEntity> UserRolesEntities { get; set; }
        public DbSet<GradingEntity> GradingEntities { get; set; }
        public DbSet<SubmissionEntity> SubmissionEntities { get; set; }
        public DbSet<FinalResultEntity> FinalResultEntities { get; set; }

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
            modelBuilder.Entity<StudentLaboratoriesEntity>()
                .HasKey(sl => new { sl.LaboratoryId, sl.StudentId });

            modelBuilder.Entity<StudentLaboratoriesEntity>()
                .HasOne(sl => sl.Student)
                .WithMany(s => s.StudentLaboratories)
                .HasForeignKey(sl => sl.StudentId);

            modelBuilder.Entity<StudentLaboratoriesEntity>()
              .HasOne(sl => sl.Laboratory)
              .WithMany(s => s.StudentLaboratories)
              .HasForeignKey(sl => sl.LaboratoryId);
        }
    }
}
