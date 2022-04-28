namespace BusinessLayer.Contracts.Models
{
    public class FinalResultModel
    {
        public int Id { get; set; }
        public StudentModel Student { get; set; }
        public string Status { get; set; }

        public FinalResultModel()
        {

        }

        public FinalResultModel(StudentModel student)
        {
            Student = student;
        }

        public FinalResultModel(int id, StudentModel student, string status)
        {
            Id = id;
            Student = student;
            Status = status;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Status: " + this.Status;
        }
    }
}
