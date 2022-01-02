using ChatOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Common.Interfaces
{
    public interface IChatOnlineDbContext
    {
        DbSet<Password> Messages { get; set; }
        DbSet<Password> Passwords { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
