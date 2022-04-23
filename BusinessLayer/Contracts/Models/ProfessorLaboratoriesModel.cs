using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class ProfessorLaboratoriesModel
    {
        public long Id { get; set; }

        public ProfessorModel Professor { get; set; }
        public LaboratoryModel Laboratory { get; set; }
        public ProfessorLaboratoriesModel()
        {
        }
    }
}
