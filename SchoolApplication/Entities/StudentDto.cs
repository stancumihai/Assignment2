using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class StudentDto 
    {
        public long Id { get; set; }

        public virtual UserDto User { get; set; }

        public string Group { get; set; }

        public string Hobby { get; set; }

        public StudentDto()
        {

        }

        public StudentDto(string group, string hobby)
        {
            Group = group;
            Hobby = hobby;
        }

        public StudentDto(long id, string group, string hobby)
        {
            Id = id;
            Group = group;
            Hobby = hobby;
        }

        public StudentDto(long id, UserDto user, string group, string hobby)
        {
            Id = id;
            User = user;
            Group = group;
            Hobby = hobby;
        }
    }
}
