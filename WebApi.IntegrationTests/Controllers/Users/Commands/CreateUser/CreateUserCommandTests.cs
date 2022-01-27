using ChatOnline.Application.Users.GetUserDetail.Commands.CreateUser;
using ChatOnlineApi;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IntegrationTests.Common;
using WebApi.IntegrationTests.Common.Helpers;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.Users.Commands.CreateUser
{
    public class CreateUserCommandTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CreateUserCommandTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task CreateNewUser_ReturnsNewUserId()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            var newUser = new CreateUserCommand
            {
                Name = "NewUser",
                Surname = "NewUserSurname"
            };

            var response = await client.PostAsync($"/api/user/register", newUser.ToJsonHttpContent());
            response.EnsureSuccessStatusCode();

            var id = await Utilities.GetResponseContent<int>(response);

            id.Should().BePositive();
        }
    }
}
