using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class LaboratoryFeeder
    {
        public static List<LaboratoryEntity> FeedLaboratoryEntities()
        {
            var laboratoryEntities = new List<LaboratoryEntity>
            {
                new LaboratoryEntity
                {
                    Id = 1,
                    LaboratoryNumber = 1,
                    Date = DateTime.Today.AddDays(2),
                    Title = "Laboratory 1",
                    Objectives = "Learning Architecture",
                    Description = "Learning Architecture Laboratory 1"
                },
                new LaboratoryEntity
                {
                    Id = 2,
                    LaboratoryNumber = 2,
                    Date = DateTime.Today.AddDays(2),
                    Title = "Laboratory 2",
                    Objectives = "Learning Architecture 2",
                    Description = "Learning Architecture 2 Laboratory 2"
                },
                new LaboratoryEntity
                {
                    Id = 3,
                    LaboratoryNumber = 3,
                    Date = DateTime.Today.AddDays(3),
                    Title = "Laboratory 3",
                    Objectives = "Learning Architecture 3",
                    Description = "Learning Architecture 3 Laboratory 3"
                },
                new LaboratoryEntity
                {
                    Id = 4,
                    LaboratoryNumber = 4,
                    Date = DateTime.Today.AddDays(3),
                    Title = "Laboratory 4",
                    Objectives = "Learning Architecture 4",
                    Description = "Learning Architecture 4 Laboratory 4"
                },
                new LaboratoryEntity
                {
                    Id = 5,
                    LaboratoryNumber = 4,
                    Date = DateTime.Today.AddDays(3),
                    Title = "Laboratory 4",
                    Objectives = "Learning Architecture 4",
                    Description = "Learning Architecture 4 Laboratory 4"
                }
            };

            return laboratoryEntities;
        }
    }
}