using ChatOnline.Application.Common.Interfaces;
using ChatOnline.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IChatOnlineDbContext _context;

        public CreateUserCommandHandler(IChatOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = request.Password; // TODO -> Add hashing

            var user = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
            };

            _context.Users.Add(user);

            var password = new Password()
            {
                UserId = user.Id,
                HashPassword = hashPassword,
            };

            _context.Passwords.Add(password);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
