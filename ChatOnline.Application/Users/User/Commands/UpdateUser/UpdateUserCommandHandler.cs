using ChatOnline.Application.Common.Exceptions;
using ChatOnline.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IChatOnlineDbContext _context;

        public UpdateUserCommandHandler(IChatOnlineDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);

            if(user == null)
                throw new NotFoundException("User not found");

            if (user != null)
            {
                if (request.Name != null)
                    user.Name = request.Name;
                if (request.Surname != null)
                    user.Surname = request.Surname;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
