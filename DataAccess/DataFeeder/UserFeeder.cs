using DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataFeeder
{
    public class UserFeeder
    {
        public static List<UserEntity> FeedUserEntites()
        {
            var userEntites = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 1,
                    Email = "1@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 2,
                    Email = "2@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 3,
                    Email = "3@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 4,
                    Email = "4@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 5,
                    Email = "5@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 6,
                    Email = "5@yahoo.com",
                    Password = "1234"
                },
                new UserEntity
                {
                    Id = 7,
                    Email = "6@yahoo.com",
                    Password = "1234"
                },new UserEntity
                {
                    Id = 8,
                    Email = "7@yahoo.com",
                    Password = "1234"
                }
            };

            return userEntites;
        }
    }
}
