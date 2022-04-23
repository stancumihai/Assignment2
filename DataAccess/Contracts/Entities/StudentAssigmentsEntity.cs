using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class StudentAssigmentsEntity
    {
        public long Id { get; set; }

        public long? StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentEntity Student { get; set; }
        public long? AssignmentId { get; set; }

        [ForeignKey("AssignmentId")]
        public AssignmentEntity Assignment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Grade { get; set; }
    }
}
