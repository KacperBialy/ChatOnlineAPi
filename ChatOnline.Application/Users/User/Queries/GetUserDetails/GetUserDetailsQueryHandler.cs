using AutoMapper;
using ChatOnline.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsViewModel>
    {
        private readonly IChatOnlineDbContext _context;
        private readonly IMapper _mapper;
        public GetUserDetailsQueryHandler(IChatOnlineDbContext chatOnlineDbContext, IMapper mapper)
        {
            _context = chatOnlineDbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(user => user.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

            var userDetailViewModel = _mapper.Map<UserDetailsViewModel>(user);
            return userDetailViewModel;
        }
    }
}
