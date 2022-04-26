namespace SchoolApplication.Entities
{
    public class StudentDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public string Group { get; set; }
        public string FullName { get; set; }

        public string Hobby { get; set; }

        public StudentDto()
        {

        }

        public StudentDto(int id, UserDto user, string group, string fullName, string hobby)
        {
            Id = id;
            User = user;
            Group = group;
            FullName = fullName;
            Hobby = hobby;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "User:" + this.User + " " + "Group:" + this.Group + " " + "Hobby: " + this.Hobby + " " + "FullName: " + this.FullName;
        }
    }
}
