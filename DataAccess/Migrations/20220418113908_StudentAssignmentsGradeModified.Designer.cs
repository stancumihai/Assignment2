﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20220418113908_StudentAssignmentsGradeModified")]
    partial class StudentAssignmentsGradeModified
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Contracts.Entities.AssignmentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LaboratoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.ToTable("AssignmentEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.LaboratoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LaboratoryNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Objectives")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProfessorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("LaboratoryEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.ProfessorEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ProfessorEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.StudentAssigments", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AssignmentId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAssigmentsEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.StudentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobby")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StudentEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passsword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserEntities");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.AssignmentEntity", b =>
                {
                    b.HasOne("DataAccess.Contracts.Entities.LaboratoryEntity", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryId");

                    b.Navigation("Laboratory");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.LaboratoryEntity", b =>
                {
                    b.HasOne("DataAccess.Contracts.Entities.ProfessorEntity", "Professor")
                        .WithMany("Laboratories")
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.ProfessorEntity", b =>
                {
                    b.HasOne("DataAccess.Contracts.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.StudentAssigments", b =>
                {
                    b.HasOne("DataAccess.Contracts.Entities.AssignmentEntity", "Assignment")
                        .WithMany("StudentAssigments")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("DataAccess.Contracts.Entities.StudentEntity", "Student")
                        .WithMany("StudentAssigments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Assignment");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.StudentEntity", b =>
                {
                    b.HasOne("DataAccess.Contracts.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.AssignmentEntity", b =>
                {
                    b.Navigation("StudentAssigments");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.ProfessorEntity", b =>
                {
                    b.Navigation("Laboratories");
                });

            modelBuilder.Entity("DataAccess.Contracts.Entities.StudentEntity", b =>
                {
                    b.Navigation("StudentAssigments");
                });
#pragma warning restore 612, 618
        }
    }
}
