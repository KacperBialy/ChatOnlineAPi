using ChatOnline.Domain.Entities;
using ChatOnline.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static void InitializeDbForTests(ChatOnlineDbContext context)
        {
            var user = new User()
            {
                Id = 1,
                StatusId = 1,
                Name = "Kacper",
                Surname = "Testowy",
                CreatedBy = "bob",
                Messages = new List<Message>()
                {
                    new Message() { Id = 1, StatusId = 1, CreatedBy = "bob", Content = "Hi, what's up?", FriendId = 2 },
                },
                Posts = new List<Post>()
                {
                    new Post()
                    {
                        Id=1,
                        StatusId = 1,
                        CreatedBy ="bob",
                        Content = "Hello, this is my first post!"
                    }
                }
                
            };

            context.Users.Add(user);

        }
    }
}
