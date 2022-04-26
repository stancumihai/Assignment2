namespace BusinessLayer.Contracts.Models
{
    public class UserRolesModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public RoleModel Role { get; set; }

        public UserRolesModel()
        {

        }

        public UserRolesModel(UserModel user, RoleModel role)
        {
            User = user;
            Role = role;
        }

        public UserRolesModel(int id, UserModel user, RoleModel role)
        {
            Id = id;
            User = user;
            Role = role;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + "User: " + this.User + "Role: " + this.Role;
        }
    }
}
