namespace DataAccess.Contracts.Entities
{
    public class UserEntity : IEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string FullName { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(string email, string passsword, string fullName)
        {
            Email = email;
            Passsword = passsword;
            FullName = fullName;
        }

        public UserEntity(long id, string email, string passsword, string fullName)
        {
            Id = id;
            Email = email;
            Passsword = passsword;
            FullName = fullName;
        }

        public override string ToString()
        {
            return "Id :" + this.Id;
        }
    }
}
