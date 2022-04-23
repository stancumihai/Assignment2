using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class ProfessorLaboratoriesEntity : IEntity
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
