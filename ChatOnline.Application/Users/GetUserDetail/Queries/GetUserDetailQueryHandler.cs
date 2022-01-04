using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetUserDetailQueryHandler(IChatOnlineDbContext chatOnlineDbContext, IMapper mapper)
        {
            _context = chatOnlineDbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailViewModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.Where(user => user.Id == request.UserId).FirstOrDefaultAsync(cancellationToken);

            var userDetailViewModel = _mapper.Map<UserDetailViewModel>(user);
            return userDetailViewModel;
        }
    }
}
