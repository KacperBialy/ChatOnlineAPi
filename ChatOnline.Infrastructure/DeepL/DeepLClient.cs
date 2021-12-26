using ChatOnline.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ChatOnline.Infrastructure.DeepL
{
    public class DeepLClient : IDeepLClient
    {
        private readonly HttpClient _httpClient;

        public DeepLClient(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("DeepLClient");
        }

        public async Task<string> GetTranslation(string text)
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);

            queryParams["text"] = text;
            queryParams["target_lang"] = "EN";

            try
            {
                var response = await _httpClient.GetAsync($"/v2/translate?{queryParams}");


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
                else
                {
                    return "Something bad happened";
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
