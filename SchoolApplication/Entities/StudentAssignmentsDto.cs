using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApplication.Entities
{
    public class StudentAssignmentsDto
    {
        public long Id { get; set; }

        public StudentDto Student { get; set; }
        public AssignmentDto Assignment { get; set; }

        public decimal Grade { get; set; }
    }
}
