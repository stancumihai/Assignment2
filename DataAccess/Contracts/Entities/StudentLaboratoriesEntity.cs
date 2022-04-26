using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class StudentLaboratoriesEntity : IEntity
    {
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

        public StudentLaboratoriesEntity(int laboratoryId, int studentId)
        {
            LaboratoryId = laboratoryId;
            StudentId = studentId;
        }

        public StudentLaboratoriesEntity(LaboratoryEntity laboratory, StudentEntity student)
        {
            Laboratory = laboratory;
            Student = student;
        }

        public StudentLaboratoriesEntity(int id, LaboratoryEntity laboratory, StudentEntity student)
        {
            Id = id;
            Laboratory = laboratory;
            Student = student;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Laboratory:" + this.Laboratory + " " + "Student: " + this.Student;
        }
    }
}
