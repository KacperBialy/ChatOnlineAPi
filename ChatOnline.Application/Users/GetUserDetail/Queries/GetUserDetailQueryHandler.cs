using ChatOnline.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Queries
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailViewModel>
    {
        private readonly IChatOnlineDbContext _context;
        public GetUserDetailQueryHandler(IChatOnlineDbContext chatOnlineDbContext)
        {
            _context = chatOnlineDbContext;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(user => user.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

            var userDetailViewModel = new UserDetailViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
            };

            return userDetailViewModel;
        }
    }
}
