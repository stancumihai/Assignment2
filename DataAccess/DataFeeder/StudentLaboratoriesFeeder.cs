using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class StudentLaboratoriesFeeder
    {
        public static List<StudentLaboratoriesEntity> FeedStudentLaboratoriesEntities()
        {
            var studentLaboratoriesEntity = new List<StudentLaboratoriesEntity>
            {
                new StudentLaboratoriesEntity
                {
                    Id = 1,
                    StudentId = 2,
                    LaboratoryId = 1
                },
                new StudentLaboratoriesEntity
                {
                    Id = 2,
                    StudentId = 2,
                    LaboratoryId = 2
                },
                new StudentLaboratoriesEntity
                {
                    Id = 3,
                    StudentId = 2,
                    LaboratoryId = 3
                },
                new StudentLaboratoriesEntity
                {
                    Id = 4,
                    StudentId = 3,
                    LaboratoryId = 1
                },
                new StudentLaboratoriesEntity
                {
                    Id = 5,
                    StudentId = 3,
                    LaboratoryId = 2
                },
                new StudentLaboratoriesEntity
                { 
                    Id = 6,
                    StudentId = 3,
                    LaboratoryId = 3
                },
                new StudentLaboratoriesEntity
                {
                    Id = 7,
                    StudentId = 3,
                    LaboratoryId = 4
                },
            };

            return studentLaboratoriesEntity;
        }
    }
}
