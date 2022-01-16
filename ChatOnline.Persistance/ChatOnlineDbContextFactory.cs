using ChatOnline.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Persistance
{
    public class ChatOnlineDbContextFactory : DesignTimeDbContextFactoryBase<ChatOnlineDbContext>
    {
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;
        public ChatOnlineDbContextFactory(IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }
        public ChatOnlineDbContextFactory()
        {

        }
        protected override ChatOnlineDbContext CreateNewInstance(DbContextOptions<ChatOnlineDbContext> options)
        {
            return new ChatOnlineDbContext(options, _dateTime, _currentUserService);
        }
    }
}
