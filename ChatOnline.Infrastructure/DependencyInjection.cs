using ChatOnline.Application.Common.Interfaces;
using ChatOnline.Infrastructure.DeepL;
using ChatOnline.Infrastructure.FileStore;
using ChatOnline.Infrastructure.Handlers;
using ChatOnline.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHttpClient("DeepLClient", options =>
            {
                options.BaseAddress = new Uri("https://api-free.deepl.com");
                options.Timeout = new TimeSpan(0, 0, 10);

                options.DefaultRequestHeaders.Add("Authorization", "DeepL-Auth-Key 7129da78-2d2b-538c-6cba-115991c4759b:fx");
                options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            })
                .ConfigurePrimaryHttpMessageHandler(sp => new LoggingRequestHandler(new HttpClientHandler()));

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();

            services.AddScoped<IDeepLClient, DeepLClient>();

            return services;
        }
    }
}
