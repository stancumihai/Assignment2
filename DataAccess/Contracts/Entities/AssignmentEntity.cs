using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class AssignmentEntity : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("LaboratoryId")]
        public virtual LaboratoryEntity Laboratory { get; set; }
        public int? LaboratoryId { get; set; }


        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        public AssignmentEntity()
        {

        }

        public AssignmentEntity(int id, LaboratoryEntity laboratory, int? laboratoryId, DateTime deadLine, string description)
        {
            Id = id;
            Laboratory = laboratory;
            LaboratoryId = laboratoryId;
            DeadLine = deadLine;
            Description = description;
        }

        public AssignmentEntity(int id, LaboratoryEntity laboratory, DateTime deadLine, string description)
        {
            Id = id;
            Laboratory = laboratory;
            DeadLine = deadLine;
            Description = description;
        }

        public override string ToString()
        {
            return 
                "Id :" + this.Id + " " +
                "Laboratory:" + this.LaboratoryId + " " +
                "DeadLine: " + this.DeadLine + " " +
                "Description: " + this.Description;
        }
    }
}
