using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class ProfessorLaboratoriesDto
    {
        public long Id { get; set; }
        public ProfessorDto Professor { get; set; }
        public LaboratoryDto Laboratory { get; set; }
    }
}
