using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess.Contracts.Entities
{
    public class StudentEntity : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }
        public int? UserId { get; set; }

        public string Group { get; set; }
        public string FullName { get; set; }
        public string Hobby { get; set; }

        public ICollection<StudentLaboratoriesEntity> StudentLaboratories { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(int id, UserEntity user, int? userId, string group, string fullName, string hobby)
        {
            Id = id;
            User = user;
            UserId = userId;
            Group = group;
            FullName = fullName;
            Hobby = hobby;
        }

        public StudentEntity(int Id, UserEntity user, string group, string fullName, string hobby)
        {
            this.Id = Id;
            User = user;
            Group = group;
            FullName = fullName;
            Hobby = hobby;
        }


        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Group:" + this.Group + " " + "Hobby: " + this.Hobby + " " + "Hobby: " + this.FullName;
        }
    }
}
