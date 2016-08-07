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
            // Add framework services.
            services.AddMvc()
                .AddDataAnnotationsLocalization();
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IdentityContext>();


            // Swagger
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = "v1",
                     Title = "Identity API",
                     Description = "Identity API for InvestSystems.org",
                     TermsOfService = "Use at your own risk",
                 })
            );
            //if (_hostingEnv.IsDevelopment())
            //{
            //    services.ConfigureSwaggerGen(c =>
            //    {
            //        c.IncludeXmlComments(GetXmlCommentsPath());
            //    });
            //}

            services.AddDbContext<IdentityContext>();
            services.AddTransient<IdentityContextSeedData>();
            services.AddScoped<IUsersService, UsersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IdentityContextSeedData seeder)
        {
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

            app.UseMvc();

            // Swagger
            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi();

            seeder.EnsureSeedData().Wait();
        }
    }
}
