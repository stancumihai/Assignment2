namespace BusinessLayer.Contracts.Models
{
    public class GradingModel
    {
        public int Id { get; set; }

        public SubmissionModel Submission { get; set; }

        public float Grade { get; set; }
        public GradingModel()
        {

        }
        public GradingModel(SubmissionModel submission, float grade)
        {
            Submission = submission;
            Grade = grade;
        }

        public GradingModel(int id, SubmissionModel submission, float grade)
        {
            Id = id;
            Submission = submission;
            Grade = grade;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Submission:" + this.Submission + " " + "Grade: " + this.Grade;
        }
    }
}
