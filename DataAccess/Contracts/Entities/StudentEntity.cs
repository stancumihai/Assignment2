using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class StudentEntity : IEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public string Group { get; set; }

        public string Hobby { get; set; }

        public List<StudentAssigmentsEntity> StudentAssigments { get; set; }
        public List<StudentLaboratoriesEntity> StudentLaboratories { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(string group, string hobby)
        {
            Group = group;
            Hobby = hobby;
        }

        public StudentEntity(long id, UserEntity user, string group, string hobby)
        {
            Id = id;
            User = user;
            Group = group;
            Hobby = hobby;
        }

        public StudentEntity(long id, long? userId, string group, string hobby)
        {
            Id = id;
            UserId = userId;
            Group = group;
            Hobby = hobby;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Group:" + this.Group + " " + "Hobby: " + this.Hobby;
        }
    }
}
