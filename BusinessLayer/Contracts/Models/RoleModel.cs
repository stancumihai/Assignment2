namespace BusinessLayer.Contracts.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleModel()
        {

        }
        
        public RoleModel(string name)
        {
            Name = name;
        }

        public RoleModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + "Name: " + this.Name;
        }
    }
}
