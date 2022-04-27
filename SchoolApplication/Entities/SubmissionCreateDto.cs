namespace SchoolApplication.Entities
{
    public class SubmissionCreateDto
    {
        public int Id { get; set; }
        public int Assignment { get; set; }
        public int Student { get; set; }
        public string Github { get; set; }
        public string Comment { get; set; }

        public SubmissionCreateDto()
        {

        }
        public SubmissionCreateDto(int id, int assignment, int student, string github, string comment)
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
