using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class StudentFeeder
    {
        public static List<StudentEntity> FeedStudentEntities()
        {
            var studentEntities = new List<StudentEntity>
            {
                new StudentEntity
                {
                    Id = 1,
                    UserId = 2,
                    FullName = "student1",
                    Group = "30231",
                    Hobby = "asd"
                },
                new StudentEntity
                {
                    Id = 2,
                    UserId = 3,
                    FullName = "student2",
                    Group = "30231",
                    Hobby = "asd"
                },
                new StudentEntity
                {
                    Id = 3,
                    UserId = 4,
                    FullName = "student3",
                    Group = "30231",
                    Hobby = "asd"
                },
                new StudentEntity
                {
                    Id = 4,
                    UserId = 5,
                    FullName = "student4",
                    Group = "30231",
                    Hobby = "asd"
                },
                new StudentEntity
                {
                    Id = 5,
                    UserId = 6,
                    FullName = "student5",
                    Group = "30231",
                    Hobby = "asd"
                }
            };
            return studentEntities;
        }
    }
}
