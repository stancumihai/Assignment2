
namespace SchoolApplication.Entities
{
    public class FinalResultDto
    {
        public int Id { get; set; }
        public StudentDto Student { get; set; }
        public string Status { get; set; }

        public FinalResultDto(StudentDto studentId, string status)
        {
            Student = studentId;
            Status = status;
        }

        public FinalResultDto(int id, StudentDto Student, string status)
        {
            Id = id;
            this.Student = Student;
            Status = status;
        }
        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Status: " + this.Status;
        }
    }
}
