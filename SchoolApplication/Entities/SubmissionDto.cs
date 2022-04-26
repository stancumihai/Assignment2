namespace SchoolApplication.Entities
{
    public class SubmissionDto
    {
        public int Id { get; set; }
        public AssignmentDto Assignment { get; set; }
        public StudentDto Student { get; set; }
        public string Github { get; set; }
        public string Comment { get; set; }

        public SubmissionDto()
        {

        }

        public SubmissionDto(int id, AssignmentDto assignment, StudentDto student, string github, string comment)
        {
            Id = id;
            Assignment = assignment;
            Student = student;
            Github = github;
            Comment = comment;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Assignment:" + this.Assignment + " " + "Student: " + this.Student + " " + "Github: " + this.Github + " " + "Comment: " + this.Comment;
        }
    }
}
