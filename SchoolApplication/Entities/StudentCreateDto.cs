namespace SchoolApplication.Entities
{
    public class StudentCreateDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Group { get; set; }

        public string Hobby { get; set; }

        public string FullName { get; set; }
        public StudentCreateDto()
        {

        }

        public StudentCreateDto(int id, int userId, string group, string hobby, string fullName)
        {
            Id = id;
            UserId = userId;
            Group = group;
            Hobby = hobby;
            FullName = fullName;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "User:" + this.UserId + " " + "Group:" + this.Group + " " + "Hobby: " + this.Hobby + " " + "FullName: " + this.FullName;
        }
    }
}
