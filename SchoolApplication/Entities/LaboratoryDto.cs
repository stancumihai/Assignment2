using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class LaboratoryDto
    {
        public long Id { get; set; }

        public long LaboratoryNumber { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Objectives { get; set; }
        public string Description { get; set; }
    }
}
