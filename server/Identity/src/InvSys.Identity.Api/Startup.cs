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
            services.AddMvc();
            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<IdentityContext>();
            services.AddDbContext<IdentityContext>();
            services.AddTransient<IdentityContextSeedData>();
            services.AddTransient<IdentityContextSeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IdentityContextSeedData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            seeder.EnsureSeedData().Wait();
        }
    }
}
