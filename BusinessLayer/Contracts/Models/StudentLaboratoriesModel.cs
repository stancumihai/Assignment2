﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class StudentLaboratoriesModel
    {
        public long Id { get; set; }

        public StudentModel Student { get; set; }

        public AssignmentModel Assignment { get; set; }

        public decimal Grade { get; set; }

        public StudentLaboratoriesModel()
        {

        }
    }
}