namespace BusinessLayer.Contracts.Models
{
    public class StudentLaboratoriesModel
    {
        public int Id { get; set; }

        public StudentModel Student { get; set; }

        public LaboratoryModel Laboratory { get; set; }

        public decimal Grade { get; set; }

        public StudentLaboratoriesModel()
        {

        }
        public StudentLaboratoriesModel(StudentModel student, LaboratoryModel laboratory, decimal grade)
        {
            Student = student;
            Laboratory = laboratory;
            Grade = grade;
        }

        public StudentLaboratoriesModel(int id, StudentModel student, LaboratoryModel laboratory, decimal grade)
        {
            Id = id;
            Student = student;
            Laboratory = laboratory;
            Grade = grade;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Laboratory: " + this.Laboratory;
        }
    }
}
