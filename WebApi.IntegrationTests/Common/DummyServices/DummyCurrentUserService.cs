using ChatOnline.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common.DummyServices
{
    public class DummyCurrentUserService : ICurrentUserService
    {
        public string UserId { get; set; } = "1";
        public string Email { get; set; } = "user@gmail.com";
        public bool IsAuthenticated { get; set; } = true;
    }
}
