using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class RoleEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserEntity> Users { get; set; }

        public RoleEntity()
        {

        }
        public RoleEntity(int id, string name)
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
