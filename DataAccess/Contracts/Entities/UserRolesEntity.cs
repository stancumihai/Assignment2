using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class UserRolesEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }

        public int? RoleId { get; set; }

        public UserRolesEntity()
        {

        }

        public UserRolesEntity(int id, UserEntity user, RoleEntity role)
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
