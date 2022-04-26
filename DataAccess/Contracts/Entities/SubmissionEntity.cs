using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Contracts.Entities
{
    public class SubmissionEntity : IEntity
    {
        public int Id { get; set; }

        [ForeignKey("AssignmentId")]
        public AssignmentEntity Assignment { get; set; }
        public int? AssignmentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentEntity Student { get; set; }
        public int? StudentId { get; set; }

        public string Github { get; set; }
        public string Comment { get; set; }
        public SubmissionEntity()
        {

        }

        public SubmissionEntity(int id, AssignmentEntity assignment, int? assignmentId, StudentEntity student, int? studentId, string github, string comment)
        {
            Id = id;
            Assignment = assignment;
            AssignmentId = assignmentId;
            Student = student;
            StudentId = studentId;
            Github = github;
            Comment = comment;
        }

        public SubmissionEntity(AssignmentEntity assignment, StudentEntity student, string github, string comment)
        {
            Assignment = assignment;
            Student = student;
            Github = github;
            Comment = comment;
        }

        public SubmissionEntity(int id, 
            AssignmentEntity assignment, 
            StudentEntity student, 
            string github, 
            string comment)
        {
            Id = id;
            Assignment = assignment;
            Student = student;
            Github = github;
            Comment = comment;
        }

        public override string ToString()
        {
            return "Id :" + this.Id + " " + 
                "Assignment:" + this.Assignment + " " + 
                "Student: " + this.Student + " " + 
                "Github: " + this.Github + " " + 
                "Comment: " + this.Comment;
        }
    }
}
