namespace BusinessLayer.Contracts.Models
{
    public class SubmissionModel
    {
        public int Id { get; set; }

        public AssignmentModel Assignment { get; set; }

        public StudentModel Student { get; set; }

        public string Github { get; set; }

        public string Comment { get; set; }

        public SubmissionModel()
        {

        }

        public SubmissionModel(AssignmentModel assignment, StudentModel student, string github, string comment)
        {
            Assignment = assignment;
            Student = student;
            Github = github;
            Comment = comment;
        }

        public SubmissionModel(int id, AssignmentModel assignment, StudentModel student, string github, string comment)
        {
            Id = id;
            Assignment = assignment;
            Student = student;
            Github = github;
            Comment = comment;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " +
                "Assignment:" + this.Assignment + " " +
                "Student: " + this.Student + " " +
                "Github: " + this.Github + " " +
                "Comment: " + this.Comment;
        }
    }
}
