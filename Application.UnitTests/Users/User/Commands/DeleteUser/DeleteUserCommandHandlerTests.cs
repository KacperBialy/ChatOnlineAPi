using Application.UnitTests.Common;
using ChatOnline.Application.Users.GetUserDetail.Commands.DeleteUser;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteUserCommandHandler _handler;
        public DeleteUserCommandHandlerTests() : base()
        {
            _handler = new DeleteUserCommandHandler(_context);
        }
        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteUser()
        {
            var command = new DeleteUserCommand()
            {
                UserId = 1
            };

            await _handler.Handle(command, CancellationToken.None);

            var user = await _context.Users.FirstAsync(x => x.Id == command.UserId, CancellationToken.None);

            user.StatusId.Should().Be(0);
        }
    }
}
