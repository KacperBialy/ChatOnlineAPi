using ChatOnlineApi;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApi.IntegrationTests.Common;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.Users.Commands.DeleteUser
{
    public class DeleteUserCommandTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DeleteUserCommandTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenExistUserId_ReturnsNotFoundStatus()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "1";

            var response = await client.DeleteAsync($"/api/user/{id}");

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
