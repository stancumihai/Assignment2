using System;

namespace SchoolApplication.Entities
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public LaboratoryDto Laboratory { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }


        public AssignmentDto()
        {

        }

        public AssignmentDto(LaboratoryDto Laboratory, DateTime deadLine, string description)
        {
            this.Laboratory = Laboratory;
            DeadLine = deadLine;
            Description = description;
        }

        public AssignmentDto(int id, LaboratoryDto Laboratory, DateTime deadLine, string description)
        {
            Id = id;
            this.Laboratory = Laboratory;
            DeadLine = deadLine;
            Description = description;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Laboratory:" + this.Laboratory + " " + "DeadLine: " + this.DeadLine + " " + "Description: " + this.Description;
        }
    }
}
