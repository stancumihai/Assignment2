using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Contracts.Entities
{
    public class ProfessorEntity : IEntity
    {
        public long Id { get; set; }

        public DateTime DOB { get; set; }
        
        [ForeignKey("UserId")]
        public virtual UserEntity User { get; set; }

        public long? UserId { get; set; }

        public ProfessorEntity()
        {

        }
        public ProfessorEntity(long id, DateTime dOB, UserEntity user)
        {
            Id = id;
            DOB = dOB;
            User = user;
        }

        public ProfessorEntity(long id, DateTime dOB, int? userId)
        {
            Id = id;
            DOB = dOB;
            UserId = userId;
        }
    }
}
