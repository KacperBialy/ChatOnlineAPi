using ChatOnline.Application;
using ChatOnline.Application.Common.Interfaces;
using ChatOnline.Infrastructure;
using ChatOnline.Infrastructure.Identity;
using ChatOnline.Persistance;
using ChatOnlineApi.Service;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChatOnlineApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAnyOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
            });

            if (Environment.IsEnvironment("Test"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("ChatOnline"));
                });

                services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();
                services.AddIdentityServer()
                        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                        {
                            options.ApiResources.Add(new ApiResource("api1"));
                            options.ApiScopes.Add(new ApiScope("ap1"));
                            options.Clients.Add(new Client()
                            {
                                ClientId = "client",
                                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },
                                ClientSecrets = { new Secret("secret".Sha256()) },
                                AllowedScopes = { "openid", "profile", "ChatOnlineApi", "api1" }
                            });
                        }).AddTestUsers(new List<TestUser>()
                        {
                            new TestUser()
                            {
                                 SubjectId = "4B434A88-212D-4A4D-A17C-F35102D73CBB" ,
                                 Username = "bob",
                                 Password = "Pass123$",
                                 Claims = new List<Claim>()
                                 {
                                     new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                                     new Claim(JwtClaimTypes.Name, "bob"),
                                 }
                            }
                        });

                services.AddAuthentication("Bearer").AddIdentityServerJwt();
            }
            else
            {
                services.AddAuthentication("Bearer")
                        .AddJwtBearer(options =>
                        {
                            options.Authority = "https://localhost:5001";
                            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                            {
                                ValidateAudience = false
                            };
                        });



                services.AddAuthorization(options =>
                {
                    options.AddPolicy("ApiScope", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope", "api1");
                    });
                });
            }

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Full acess"},
                                {"user", "User info"}
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ChatOnlineApi",
                    Version = "v1",
                    Description = "Api to manage users and their chat messages",
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "ChatOnlineApi.xml");
                options.IncludeXmlComments(filePath);
            });


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatOnlineApi");
                    options.OAuthClientId("swagger");
                    options.OAuth2RedirectUrl("https://localhost:44325/swagger/oauth2-redirect.html");
                    options.OAuthUsePkce();
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseSerilogRequestLogging();

            app.UseRouting();
            app.UseAuthorization();
            if(Environment.IsEnvironment("Test"))
            {
                app.UseIdentityServer();
            }

            app.UseCors();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                         .RequireAuthorization("ApiScope");
            });
        }
    }
}
