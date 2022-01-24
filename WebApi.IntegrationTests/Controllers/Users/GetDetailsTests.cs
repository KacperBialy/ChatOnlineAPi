using ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails;
using ChatOnlineApi;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.IntegrationTests.Common;
using Xunit;

namespace WebApi.IntegrationTests.Controllers.Users
{
    public class GetDetailsTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetDetailsTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenUserId_ReturnsUsersDetail()
        {
            var client = await _factory.GetAuthenticatedClientAsync();

            string id = "1";
            var response = await client.GetAsync($"/api/user/{id}");
            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<UserDetailsViewModel>(response);

            vm.Should().NotBeNull();
        }
    }
}
