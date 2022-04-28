using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class GradingFeeder
    {
        public static List<GradingEntity> FeedGradingEntities()
        {
            var gradingEntities = new List<GradingEntity>
            {
                new GradingEntity
                {
                    Id = 1,
                    SubmissionId = 1,
                    Grade = 6
                },
                new GradingEntity
                {
                    Id = 2,
                    SubmissionId = 2,
                    Grade = 6
                },
                new GradingEntity
                {
                    Id = 3,
                    SubmissionId = 3,
                    Grade = 6
                },
                new GradingEntity
                {
                    Id = 4,
                    SubmissionId = 4,
                    Grade = 5
                },
                new GradingEntity
                {
                    Id = 5,
                    SubmissionId = 5,
                    Grade = 5
                },
                new GradingEntity
                {
                    Id = 6,
                    SubmissionId = 6,
                    Grade = 5
                },
            };
            return gradingEntities;
        }
    }
}
