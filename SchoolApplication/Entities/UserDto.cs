using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public string FullName { get; set; }

        public UserDto()
        {

        }
        public UserDto(string email, string passsword, string fullName)
        {
            Email = email;
            Passsword = passsword;
            FullName = fullName;
        }

        public UserDto(long id, string email, string passsword, string fullName)
        {
            Id = id;
            Email = email;
            Passsword = passsword;
            FullName = fullName;
        }
    }
}
