using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InvSys.Identity.State.EntityFramework;
using InvSys.Identity.State.EntityFramework.Seed;
using InvSys.Identity.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Swashbuckle.Swagger.Model;
using InvSys.Identity.Core.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Infrastructure;
using OpenIddict;
using CryptoHelper;

namespace InvSys.Identity.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Add framework services.
            services.AddMvc()
                .AddDataAnnotationsLocalization();
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddOpenIddict<User, IdentityContext>()
                .EnableTokenEndpoint("/connect/token")
                .EnableUserinfoEndpoint("/connect/userinfo")
                .EnableIntrospectionEndpoint("/introspective")
                .AllowPasswordFlow()
                .DisableHttpsRequirement()
                .AddEphemeralSigningKey();
            
            // Swagger
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = Configuration["Swagger:Version"],
                     Title = Configuration["Swagger:Title"],
                     Description = Configuration["Swagger:Description"],
                     TermsOfService = Configuration["Swagger:TermsOfService"]
                 })
            );
            //if (_hostingEnv.IsDevelopment())
            //{
            //    services.ConfigureSwaggerGen(c =>
            //    {
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //    });
            //}

            var connection = Configuration["ConnectionStrings:IdentityContextConnection"];
            services.AddDbContext<IdentityContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IdentityContextSeedData>();
            services.AddScoped<IUsersService, UsersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IdentityContextSeedData seeder)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            var supportedCultures = Configuration["Globalization:SupportedCultures"].Split(';').Select(c => new CultureInfo(c.Trim())).ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(Configuration["Globalization:DefaultCulture"]),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentity();
            app.UseOAuthValidation();
            app.UseOpenIddict();

            app.UseMvc();

            // Swagger
            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi();


            using (var context = new IdentityContext())
            {
                context.Database.EnsureCreated();

                if (!context.Applications.Any())
                {
                    context.Applications.Add(new OpenIddictApplication
                    {
                        ClientId = "resource_server",
                        Id = "resource_server",
                        DisplayName = "Main resource server",
                        ClientSecret = Crypto.HashPassword("secret_secret_secret"),
                        Type = OpenIddictConstants.ClientTypes.Confidential
                    });

                    context.SaveChanges();
                }
            }
            seeder.EnsureSeedData().Wait();
        }
    }
}
