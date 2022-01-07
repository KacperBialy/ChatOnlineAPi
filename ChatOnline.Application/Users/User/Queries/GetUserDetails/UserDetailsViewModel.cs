using AutoMapper;
using ChatOnline.Application.Common.Mappings;
using ChatOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Application.Users.GetUserDetail.Queries.GetUserDetails
{
    public class UserDetailsViewModel : IMapFrom<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
