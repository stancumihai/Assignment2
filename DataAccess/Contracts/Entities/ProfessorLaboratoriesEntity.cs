using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class ProfessorLaboratoriesEntity
    {
        public long Id { get; set; }

        public long? ProfessorId { get; set; }
        
        [ForeignKey("ProfessorId")]
        public ProfessorEntity Professor { get; set; }
        public long? LaboratoryId { get; set; }
        
        [ForeignKey("LaboratoryId")]
        public LaboratoryEntity Laboratory { get; set; }
    }
}
