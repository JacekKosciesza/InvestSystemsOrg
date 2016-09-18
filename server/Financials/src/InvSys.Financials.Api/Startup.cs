using AutoMapper;
using InvSys.Financials.Core.Services;
using InvSys.Financials.Core.State;
using InvSys.Financials.State.EntityFramework;
using InvSys.Financials.State.EntityFramework.Repositories;
using InvSys.Financials.State.EntityFramework.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using InvSys.Shared.Api.Startup;

namespace InvSys.Financials.Api
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
        //private readonly MapperConfiguration _mapperConfiguration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInvSys(Configuration);

            services.AddDbContext<FinancialsContext>();
            services.AddTransient<FinancialsContextSeedData>();
            services.AddScoped<IFinancialsService, FinancialsService>();
            services.AddScoped<IFinancialDataRepository, FinancialDataRepository>();
            //services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, FinancialsContextSeedData seeder)
        {
            app.UseInvSys(Configuration, loggerFactory);

            seeder.EnsureSeedData().Wait();
        }
    }
}
