using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class AssignmentModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        public LaboratoryModel Laboratory { get; set; }

        public List<StudentAssigmentsModel> StudentAssigments { get; set; }

        public AssignmentModel()
        {

        }

        public AssignmentModel(long id, string name, 
            DateTime deadLine, 
            string description, 
            LaboratoryModel laboratory)
        {
            Id = id;
            Name = name;
            DeadLine = deadLine;
            Description = description;
            Laboratory = laboratory;
        }
    }
}
