using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class GradingEntity : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("SubmissionId")]
        public SubmissionEntity Submission { get; set; }

        public int? SubmissionId { get; set; }

        public float Grade { get; set; }

        public GradingEntity()
        {

        }

        public GradingEntity(int id, SubmissionEntity submission, float grade)
        {
            Id = id;
            Submission = submission;
            Grade = grade;
        }

        public GradingEntity(int id, SubmissionEntity submission, int? submissionId, float grade)
        {
            Id = id;
            Submission = submission;
            SubmissionId = submissionId;
            Grade = grade;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + "Submission:" + this.Submission + " " + "Grade: " + this.Grade;
        }
    }
}
