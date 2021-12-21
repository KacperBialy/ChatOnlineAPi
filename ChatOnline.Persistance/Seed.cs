using ChatOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
                }

           });
        }
    }
}
