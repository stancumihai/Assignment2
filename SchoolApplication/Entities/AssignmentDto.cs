using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class AssignmentDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        public LaboratoryDto Laboratory { get; set; }

        public AssignmentDto()
        {

        }

        public AssignmentDto(long id, string name,
            DateTime deadLine,
            string description,
            LaboratoryDto laboratory)
        {
            Id = id;
            Name = name;
            DeadLine = deadLine;
            Description = description;
            Laboratory = laboratory;
        }
    }
}
