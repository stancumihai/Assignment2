namespace SchoolApplication.Entities
{
    public class StudentLaboratoriesDto
    {
        public int Id { get; set; }
        public LaboratoryDto Laboratory { get; set; }
        public StudentDto Student { get; set; }

        public StudentLaboratoriesDto(LaboratoryDto laboratory, StudentDto student)
        {
            Laboratory = laboratory;
            Student = student;
        }

        public StudentLaboratoriesDto(int id, LaboratoryDto laboratory, StudentDto student)
        {
            Id = id;
            Laboratory = laboratory;
            Student = student;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Assignment: " + this.Laboratory;
        }
    }
}
