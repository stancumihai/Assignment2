using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class AssignmentFeeder
    {
        public static List<AssignmentEntity> FeedAssignmentEntities()
        {
            var assignmentEntities = new List<AssignmentEntity>
            {
                new AssignmentEntity
                {
                    Id = 1,
                    LaboratoryId = 1,
                    DeadLine = DateTime.Now,
                    Description = "Assignment1"
                },
                new AssignmentEntity
                {
                    Id = 2,
                    LaboratoryId = 1,
                    DeadLine = DateTime.Now,
                    Description = "Assignment1"
                },
                new AssignmentEntity
                {
                    Id = 3,
                    LaboratoryId = 2,
                    DeadLine = DateTime.Now,
                    Description = "Assignment2"
                },
                new AssignmentEntity
                {
                    Id = 4,
                    LaboratoryId = 2,
                    DeadLine = DateTime.Now,
                    Description = "Assignment2"
                },
                new AssignmentEntity
                {
                    Id = 5,
                    LaboratoryId = 3,
                    DeadLine = DateTime.Now,
                    Description = "Assignment3"
                },
                new AssignmentEntity
                {
                    Id = 6,
                    LaboratoryId = 3,
                    DeadLine = DateTime.Now,
                    Description = "Assignment3"
                },
                new AssignmentEntity
                {
                    Id = 7,
                    LaboratoryId = 4,
                    DeadLine = DateTime.Now,
                    Description = "Assignment4"
                },
                 new AssignmentEntity
                {
                    Id = 8,
                    LaboratoryId = 4,
                    DeadLine = DateTime.Now,
                    Description = "Assignment4"
                },
                  new AssignmentEntity
                {
                    Id = 9,
                    LaboratoryId = 5,
                    DeadLine = DateTime.Now,
                    Description = "Assignment5"
                },
                   new AssignmentEntity
                {
                    Id = 10,
                    LaboratoryId = 5,
                    DeadLine = DateTime.Now,
                    Description = "Assignment5"
                }
            };
            return assignmentEntities;
        }
    }
}
