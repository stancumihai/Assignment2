namespace SchoolApplication.Entities
{
    public class GradingCreateDto
    {
        public int Id { get; set; }

        public int Submission { get; set; }

        public float Grade { get; set; }

        public GradingCreateDto()
        {

        }

        public GradingCreateDto(int id, int submission, float grade)
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
