namespace BusinessLayer.Contracts.Models
{
    public class StudentLaboratoriesModel
    {
        public int Id { get; set; }

        public virtual StudentModel Student { get; set; }

        public virtual LaboratoryModel Laboratory { get; set; }

        public StudentLaboratoriesModel()
        {

        }
        public StudentLaboratoriesModel(StudentModel student, LaboratoryModel laboratory)
        {
            Student = student;
            Laboratory = laboratory;
        }

        public StudentLaboratoriesModel(int id, StudentModel student, LaboratoryModel laboratory)
        {
            Id = id;
            Student = student;
            Laboratory = laboratory;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Laboratory: " + this.Laboratory;
        }
    }
}
