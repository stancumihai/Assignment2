using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class ProfessorModel
    {
        public long Id { get; set; }

        public DateTime DOB { get; set; }

        public UserModel User { get; set; }


        public ProfessorModel()
        {

        }

        public ProfessorModel(long id, DateTime dOB, UserModel user)
        {
            Id = id;
            DOB = dOB;
            User = user;
        }
    }
}
