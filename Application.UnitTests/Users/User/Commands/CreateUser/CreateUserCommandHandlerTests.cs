using Application.UnitTests.Common;
using ChatOnline.Application.Users.GetUserDetail.Commands.CreateUser;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users.User.Commands.CreateUser
{
    public class CreateUserCommandHandlerTests : CommandTestBase
    {
        private readonly CreateUserCommandHandler _handler;
        public CreateUserCommandHandlerTests() : base()
        {
            _handler = new CreateUserCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertUser()
        {
            var command = new CreateUserCommand()
            {
                Name = "Fake",
                Surname = "Surname",
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var user = _context.Users.FirstAsync(x => x.Id == result, CancellationToken.None);

            user.Should().NotBeNull();
        }
    }
}
