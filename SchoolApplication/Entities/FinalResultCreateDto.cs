namespace SchoolApplication.Entities
{
    public class FinalResultCreateDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; }
        public FinalResultCreateDto()
        {

        }
        public FinalResultCreateDto(int id, int studentId, string status)
        {
            Id = id;
            StudentId = studentId;
            Status = status;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.StudentId + " " + "Status: " + this.Status;
        }
    }
}
