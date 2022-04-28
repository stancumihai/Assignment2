using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class SubmissionFeeder
    {
        public static List<SubmissionEntity> FeedSubmissionEntities()
        {
            var submissionEntities = new List<SubmissionEntity>
            {
                new SubmissionEntity
                {
                    Id =  1 ,
                    AssignmentId = 1,
                    StudentId = 2,
                    Github = "asd",
                    Comment = "asd"
                },

                new SubmissionEntity
                {
                    Id =  2 ,
                    AssignmentId = 2,
                    StudentId = 2,
                    Github = "asd",
                    Comment = "asd"
                },

                new SubmissionEntity
                {
                    Id =  3 ,
                    AssignmentId = 3,
                    StudentId = 2,
                    Github = "asd",
                    Comment = "asd"
                },

                new SubmissionEntity
                {
                    Id =  4 ,
                    AssignmentId = 1,
                    StudentId = 3,
                    Github = "asd",
                    Comment = "asd"
                },

                new SubmissionEntity
                {
                    Id =  5 ,
                    AssignmentId = 2,
                    StudentId = 3,
                    Github = "asd",
                    Comment = "asd"
                },

                new SubmissionEntity
                {
                    Id =  6 ,
                    AssignmentId = 3,
                    StudentId = 3,
                    Github = "asd",
                    Comment = "asd"
                },

            };
            return submissionEntities;
        }
    }
}
