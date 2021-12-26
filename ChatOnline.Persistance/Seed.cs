using ChatOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatOnline.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
           {
                new User()
                {
                    Id = 1,
                    Name = "Kacper",
                    Surname = "Nowak"
                },

                new User()
                {
                    Id = 2,
                    Name = "Emil",
                    Surname = "Pawłowski"
                },

                new User()
                {
                    Id = 3,
                    Name = "Kuba",
                    Surname = "Czarnobrody"
                },
                new User()
                {
                    Id = 4,
                    Name = "Adam",
                    Surname = "Malisz"
                },

           });

            modelBuilder.Entity<Message>().HasData(new Message[]
            {
                new Message(){ Id = 1, FriendId = 2, Content = "Hi, what's up?", UserId = 1, Date = DateTime.Now},
                new Message(){ Id = 2, FriendId = 1, Content = "I'm fine! And you?", UserId = 2, Date = DateTime.Now.AddDays(1)}
            }
            ) ;
        }
    }
}
