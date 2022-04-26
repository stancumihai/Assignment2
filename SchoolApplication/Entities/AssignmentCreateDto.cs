using System;

namespace SchoolApplication.Entities
{
    public class AssignmentCreateDto
    {

        public int Id { get; set; }
        public int LaboratoryId { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        public AssignmentCreateDto()
        {

        }

        public AssignmentCreateDto(int id, int laboratoryId, DateTime deadLine, string description)
        {
            Id = id;
            LaboratoryId = laboratoryId;
            DeadLine = deadLine;
            Description = description;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Laboratory:" + this.LaboratoryId + " " + "DeadLine: " + this.DeadLine + " " + "Description: " + this.Description;
        }
    }
}
