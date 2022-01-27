using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common.Helpers
{
    public static class HttpContentHelper
    {
        public static HttpContent ToJsonHttpContent(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
