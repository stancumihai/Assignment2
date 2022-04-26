using System;

namespace SchoolApplication.Entities
{
    public class LaboratoryDto
    {
        public int Id { get; set; }

        public int LaboratoryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives { get; set; }
        public string Description { get; set; }

        public LaboratoryDto()
        {

        }

        public LaboratoryDto(int id, int laboratoryNumber, DateTime date, string title, string objectives, string description)
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
            return "Id :" + this.Id + " " + "LaboratoryNumber:" + this.LaboratoryNumber + " " + "Date: " + this.Date;
        }
    }
}
