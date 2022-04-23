using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Contracts.Models
{
    public class StudentModel
    {
        public long Id { get; set; }

        public virtual UserModel User { get; set; }

        public string Group { get; set; }

        public string Hobby { get; set; }

        public StudentModel()
        {

        }

        public StudentModel(string group, string hobby)
        {
            Group = group;
            Hobby = hobby;
        }

        public StudentModel(long id, string group, string hobby)
        {
            Id = id;
            Group = group;
            Hobby = hobby;
        }

        public StudentModel(long id, UserModel user, string group, string hobby)
        {
            Id = id;
            User = user;
            Group = group;
            Hobby = hobby;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Group:" + this.Group + " " + "Hobby: " + this.Hobby;
        }
    }
}
