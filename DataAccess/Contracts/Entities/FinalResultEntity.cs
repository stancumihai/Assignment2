using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class FinalResultEntity : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("StudentId")]
        public StudentEntity Student { get; set; }
        public int? StudentId { get; set; }
        public string Status { get; set; }
        public FinalResultEntity()
        {

        }

        public FinalResultEntity(int id, StudentEntity student, string status)
        {
            Id = id;
            Student = student;
            Status = status;
        }

        public FinalResultEntity(int id, StudentEntity student, int? studentId, string status)
        {
            Id = id;
            Student = student;
            StudentId = studentId;
            Status = status;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Status: " + this.Status;
        }
    }
}
