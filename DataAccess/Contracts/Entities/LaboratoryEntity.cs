using System;
using System.Collections.Generic;

namespace DataAccess.Contracts.Entities
{
    public class LaboratoryEntity : IEntity
    {
        public int Id { get; set; }

        public int LaboratoryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives { get; set; }
        public string Description { get; set; }

        public ICollection<StudentLaboratoriesEntity> StudentLaboratories { get; set; }
        public LaboratoryEntity()
        {

        }

        public LaboratoryEntity(int laboratoryNumber, DateTime date, string title, string objectives, string description)
        {
            LaboratoryNumber = laboratoryNumber;
            Date = date;
            Title = title;
            Objectives = objectives;
            Description = description;
        }

        public LaboratoryEntity(int id, int laboratoryNumber, DateTime date, string title, string objectives, string description)
        {
            Id = id;
            LaboratoryNumber = laboratoryNumber;
            Date = date;
            Title = title;
            Objectives = objectives;
            Description = description;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "LaboratoryNumber:" + this.LaboratoryNumber +
                " " + "Date: " + this.Date +
                " " + "Title: " + this.Title +
                " " + "Objectives: " + this.Objectives +
                " " + "Description: " + this.Description;
        }
    }
}
