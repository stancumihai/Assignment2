using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class LaboratoryEntity
    {
        public long Id { get; set; }

        public long LaboratoryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives{ get; set; }
        public string Description{ get; set; }

        public List<StudentLaboratoriesEntity> StudentLaboratories { get; set; }
        public List<ProfessorLaboratoriesEntity> ProfessorLaboratories { get; set; }

        public LaboratoryEntity()
        {

        }

        public LaboratoryEntity(long laboratoryNumber, DateTime date, string title, string objectives, string description)
        {
            LaboratoryNumber = laboratoryNumber;
            Date = date;
            Title = title;
            Objectives = objectives;
            Description = description;
        }

        public LaboratoryEntity(long id, long laboratoryNumber, DateTime date, string title, string objectives, string description)
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
