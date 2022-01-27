using Application.UnitTests.Common;
using ChatOnline.Application.Common.Exceptions;
using ChatOnline.Application.Users.User.Commands.UpdateUser;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Users.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateUserCommandHandler _handler;
        private const int NonExistingUserId = 999;
        public UpdateUserCommandHandlerTests() : base()
        {
            _handler = new UpdateUserCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertUser()
        {
            var command = new UpdateUserCommand()
            {
                Id = 1,
                Name = "Fake",
                Surname = "Surname",
            };

            await _handler.Handle(command, CancellationToken.None);

            var user = await _context.Users.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            user.Name.Should().Be(command.Name);
            user.Surname.Should().Be(command.Surname);
        }

        [Fact]
        public async Task Handle_GivenInvalidRequest_ShouldThrowNotFoundExceptionException_WithUserNotFoundMessage()
        {
            var command = new UpdateUserCommand()
            {
                Id = NonExistingUserId,
                Name = "Fake",
                Surname = "Surname",
            };

            Func<Task> handle = async () => await _handler.Handle(command, CancellationToken.None);

            handle.Should().Throw<NotFoundException>().WithMessage("User not found");
        }
    }
}
