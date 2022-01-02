using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Queries
{
    public class GetUserDetailQuery : IRequest<UserDetailViewModel>
    {
        public int UserId { get; set; }
    }
}
