using ChatOnline.Domain.Entities;
using ChatOnline.Persistance;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class Utilities
    {
        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }
        public static void InitializeDbForTests(ChatOnlineDbContext context)
        {
            var user = new User()
            {
                StatusId = 1,
                Name = "Kacper",
                Surname = "Testowy",
                CreatedBy = "bob",
            };

            context.Users.Add(user);
            context.SaveChanges();

            var message = new Message()
            {
                StatusId = 1,
                CreatedBy = "bob",
                Content = "Hi, what's up?",
                UserId = user.Id,
            };

            context.Messages.Add(message);

            var post = new Post()
            {
                StatusId = 1,
                CreatedBy = "bob",
                Content = "Hello, this is my first post!",
                UserId = user.Id
            };

            context.Posts.Add(post);

            context.SaveChanges();
        }
    }
}
