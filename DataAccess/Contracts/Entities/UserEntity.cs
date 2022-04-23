using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Entities
{
    public class UserEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string FullName { get; set; }

        public UserEntity()
        {

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
