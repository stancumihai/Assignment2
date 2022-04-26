using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public ICollection<RoleEntity> Roles { get; set; }

        public UserEntity()
        {

        }

        public UserEntity(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserEntity(int id, string email, string password)
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
