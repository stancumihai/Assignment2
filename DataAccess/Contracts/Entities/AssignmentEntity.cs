using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class AssignmentEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        [ForeignKey("LaboratoryId")]
        public virtual LaboratoryEntity Laboratory { get; set; }
        public long? LaboratoryId { get; set; }

        public List<StudentAssigmentsEntity> StudentAssigments { get; set; }

        public AssignmentEntity()
        {
                
        }


    }
}
