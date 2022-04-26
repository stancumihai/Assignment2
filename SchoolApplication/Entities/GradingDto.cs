

namespace SchoolApplication.Entities
{
    public class GradingDto
    {
        public int Id { get; set; }

        public SubmissionDto Submission { get; set; }

        public float Grade { get; set; }

        public GradingDto()
        {

        }

        public GradingDto(SubmissionDto Submission, float grade)
        {
            this.Submission = Submission;
            Grade = grade;
        }

        public GradingDto(int id, SubmissionDto Submission, float grade)
        {
            Id = id;
            this.Submission = Submission;
            Grade = grade;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Submission:" + this.Submission + " " + "Grade: " + this.Grade;
        }
    }
}
