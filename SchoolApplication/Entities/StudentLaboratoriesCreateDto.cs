using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplication.Entities
{
    public class StudentLaboratoriesCreateDto
    {
        public int Id { get; set; }
        public int Laboratory { get; set; }
        public int Student { get; set; }

        public StudentLaboratoriesCreateDto()
        {

        }

        public StudentLaboratoriesCreateDto(int id, int laboratory, int student)
        {
            Id = id;
            Laboratory = laboratory;
            Student = student;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Student:" + this.Student + " " + "Assignment: " + this.Laboratory;
        }
    }
}
