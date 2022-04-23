using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class ProfessorDto
    {
        public long Id { get; set; }

        public DateTime DOB { get; set; }

        public UserDto User { get; set; }


        public ProfessorDto()
        {

        }

        public ProfessorDto(long id, DateTime dOB, UserDto user)
        {
            Id = id;
            DOB = dOB;
            User = user;
        }
    }
}
