using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Persistance
{
    public class ChatOnlineDbContext : DbContext
    {
        public ChatOnlineDbContext(DbContextOptions<ChatOnlineDbContext> options) : base(options)
        {

        }
    }
}
