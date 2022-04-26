using System;

namespace BusinessLayer.Contracts.Models
{
    public class AssignmentModel
    {
        public int Id { get; set; }
        public LaboratoryModel Laboratory { get; set; }

        public DateTime DeadLine { get; set; }

        public string Description { get; set; }

        public AssignmentModel()
        {

        }

        public AssignmentModel(int id, DateTime deadLine, string description)
        {
            Id = id;
            DeadLine = deadLine;
            Description = description;
        }

        public AssignmentModel(int id, LaboratoryModel laboratory, DateTime deadLine, string description)
        {
            Id = id;
            Laboratory = laboratory;
            DeadLine = deadLine;
            Description = description;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Laboratory:" + this.Laboratory + " " + "DeadLine: " + this.DeadLine + " " + "Description: " + this.Description;
        }
    }
}
