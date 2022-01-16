using ChatOnline.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly ChatOnlineDbContext _context;
        protected readonly Mock<ChatOnlineDbContext> _contextMock;
        public CommandTestBase()
        {
            _contextMock = ChatOnlineDbContextFactory.Create();
            _context = _contextMock.Object;
        }
        public void Dispose()
        {
            ChatOnlineDbContextFactory.Destroy(_context);
        }
    }
}
