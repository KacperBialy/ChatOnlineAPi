using ChatOnline.Application.Common.Interfaces;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ChatOnlineApi.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);
            var userId = httpContextAccessor.HttpContext?.User?.FindFirstValue("userName");

            Email = email;
            UserId = userId;

            IsAuthenticated = !string.IsNullOrEmpty(userId);
        }
    }
}
