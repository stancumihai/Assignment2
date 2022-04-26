namespace BusinessLayer.Contracts.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel()
        {

        }


        public UserModel(int id, string email, string password)
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
