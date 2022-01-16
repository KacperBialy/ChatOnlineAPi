using Application.UnitTests.Common;
using AutoMapper;
using ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails;
using ChatOnline.Persistance;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users.User.Queries.GetUserDetails
{
    [Collection("QueryCollection")]
    public class GetUserDetailsQueryHandlerTests : IClassFixture<QueryTestFixture>
    {
        private readonly ChatOnlineDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task CanGetUserDetailsById()
        {
            var handler = new GetUserDetailsQueryHandler(_context, _mapper);
            var userId = 5;

            var result = await handler.Handle(new GetUserDetailsQuery() { UserId = userId }, CancellationToken.None);

            result.Should().BeOfType<UserDetailsViewModel>();
            result.Name.Should().Be("Bob");
            result.Surname.Should().Be("Bobson");
        }
    }
}
