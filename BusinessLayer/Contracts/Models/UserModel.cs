using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string FullName { get; set; }

        public UserModel()
        {

        }

        public UserModel(long id, string email, string passsword, string fullName)
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
