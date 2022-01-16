using ChatOnline.Application.Common.Interfaces;
using ChatOnline.Domain.Entities;
using ChatOnline.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;

namespace Application.UnitTests.Common
{
    public static class ChatOnlineDbContextFactory
    {
        public static Mock<ChatOnlineDbContext> Create()
        {
            var dateTime = new DateTime(2000, 1, 1);
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            var currentUserMock = new Mock<ICurrentUserService>();
            currentUserMock.Setup(m => m.UserId).Returns("bob");
            currentUserMock.Setup(m => m.IsAuthenticated).Returns(true);

            var options = new DbContextOptionsBuilder<ChatOnlineDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mock = new Mock<ChatOnlineDbContext>(options, dateTimeMock.Object, currentUserMock.Object)
            {
                CallBase = true //If a method is not configured, use the base one
            };

            var context = mock.Object;

            context.Database.EnsureCreated();


            var user = new User() { Id = 5, StatusId = 1, Name = "Bob", Surname = "Bobson" };
            context.Users.Add(user);


            var post = new Post()
                {
                    Content = "Hello world",
                    Date = dateTime,
                    UserId = 5,
                    User = user,
                    CreatedBy = "bob"
                };

            context.Posts.Add(post);

            context.SaveChanges();

            return mock;
        }

        public static void Destroy(ChatOnlineDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
