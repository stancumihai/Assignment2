namespace SchoolApplication.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDto()
        {

        }
        public UserDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserDto(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + "Email: " + this.Email + "Password: " + this.Password;
        }
    }
}
