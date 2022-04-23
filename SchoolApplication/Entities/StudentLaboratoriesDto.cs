using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class StudentLaboratoriesDto
    {
        public long Id { get; set; }
        public LaboratoryDto Laboratory { get; set; }
        public StudentDto Student { get; set; }
    }
}
