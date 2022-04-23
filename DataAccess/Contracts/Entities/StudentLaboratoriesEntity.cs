using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class StudentLaboratoriesEntity
    {
        public long Id { get; set; }

        [ForeignKey("LaboratoryId")]
        public LaboratoryEntity Laboratory { get; set; }
        public StudentEntity Student { get; set; }
        [ForeignKey("StudentId")]
        public long? LaboratoryId { get; set; }
        public long? StudentId{ get; set; }
    }
}
