using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsViewModel>
    {
        public int UserId { get; set; }
    }
}
