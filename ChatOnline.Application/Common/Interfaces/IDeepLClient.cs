using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatOnline.Application.Common.Interfaces
{
    public interface IDeepLClient
    {
        Task<string> GetTranslation(string text);
    }
}
