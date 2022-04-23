using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class LaboratoryModel
    {
        public long Id { get; set; }

        public long LaboratoryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives { get; set; }
        public string Description { get; set; }

        public LaboratoryModel()
        {

        }

        public LaboratoryModel(long id, long laboratoryNumber, DateTime date, string title, string objectives, string description)
        {
            Id = id;
            LaboratoryNumber = laboratoryNumber;
            Date = date;
            Title = title;
            Objectives = objectives;
            Description = description;
        }
    }
}
