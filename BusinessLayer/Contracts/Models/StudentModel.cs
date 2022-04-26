namespace BusinessLayer.Contracts.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public virtual UserModel User { get; set; }

        public string Group { get; set; }

        public string Hobby { get; set; }

        public string FullName { get; set; }

        public StudentModel()
        {

        }

        public StudentModel(UserModel user, string group, string hobby, string fullName)
        {
            User = user;
            Group = group;
            Hobby = hobby;
            FullName = fullName;
        }

        public StudentModel(int id, UserModel user, string group, string hobby, string fullName)
        {
            Id = id;
            User = user;
            Group = group;
            Hobby = hobby;
            FullName = fullName;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + "User:  " + this.User + "Group:" + this.Group + " " + "Hobby: " + this.Hobby + " " + "FullName: " + this.FullName;
        }
    }
}
