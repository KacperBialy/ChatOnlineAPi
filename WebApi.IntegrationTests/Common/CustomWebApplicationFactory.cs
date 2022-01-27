using ChatOnline.Application.Common.Interfaces;
using ChatOnline.Infrastructure.Services;
using ChatOnline.Persistance;
using ChatOnlineApi;
using ChatOnlineApi.Service;
using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            try
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();


                    services.AddDbContext<ChatOnlineDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDatabaseForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                    services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
                    services.AddTransient<IDateTime, DateTimeService>();

                    services.AddScoped<IChatOnlineDbContext>(provider => provider.GetService<ChatOnlineDbContext>());

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();

                    var scopedService = scope.ServiceProvider;
                    var context = scopedService.GetService<ChatOnlineDbContext>();
                    var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occured seeding the database with test message. Error: {ex.Message}");
                    }
                })
                    .UseSerilog()
                    .UseEnvironment("Test");
            }
            catch (Exception)
            {
                throw;
            }

            base.ConfigureWebHost(builder);
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync()
        {
            var client = CreateClient();

            var token = await GetAccessTokenAsync(client, "bob", "Pass123$");
            client.SetBearerToken(token);
            return client;
        }

        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
            var disco = await client.GetDiscoveryDocumentAsync();

            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                ClientId = "client",
                Address = disco.TokenEndpoint,
                ClientSecret = "secret",
                Scope = "api1",
                UserName = userName,
                Password = password
            });

            if (response.IsError)
            {
                throw new Exception(response.Error);
            }

            return response.AccessToken;
        }
    }
}
