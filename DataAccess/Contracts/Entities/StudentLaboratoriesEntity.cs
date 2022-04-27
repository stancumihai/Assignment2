using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class StudentLaboratoriesEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LaboratoryId")]
        public LaboratoryEntity Laboratory { get; set; }
        public int? LaboratoryId { get; set; }

        public StudentEntity Student { get; set; }
        [ForeignKey("StudentId")]
        public int? StudentId { get; set; }

        public StudentLaboratoriesEntity()
        {

        }

        public StudentLaboratoriesEntity(int id, LaboratoryEntity laboratory, int? laboratoryId, StudentEntity student, int? studentId)
        {
            Id = id;
            Laboratory = laboratory;
            LaboratoryId = laboratoryId;
            Student = student;
            StudentId = studentId;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Laboratory:" + this.Laboratory + " " + "Student: " + this.Student;
        }
    }
}
