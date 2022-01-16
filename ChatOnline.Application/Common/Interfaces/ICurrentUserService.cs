using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatOnline.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; set; }
        string Email { get; set; }
        bool IsAuthenticated { get; set; }
    }
}
