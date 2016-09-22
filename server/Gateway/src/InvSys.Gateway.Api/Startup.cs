using AutoMapper;
using InvSys.Companies.Api.Client.Proxy;
using InvSys.Gateway.Core.GraphQLTest;
using InvSys.Gateway.Core.Services;
using InvSys.RuleOne.Api.Client.Proxy;
using InvSys.Shared.Api.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InvSys.Gateway.Api
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

            _mapperConfiguration = new MapperConfiguration(Mapper.Configure);
        }

        public IConfigurationRoot Configuration { get; }
        private readonly MapperConfiguration _mapperConfiguration;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddInvSysLocalization();
            services.AddInvSysConfiguration(Configuration);
            services.AddMvc().AddDataAnnotationsLocalization();
            services.AddInvSysAuthorization();

            services.AddTransient<IStarWarsGraphQL, StarWarsGraphQL>();
            services.AddTransient<IDashboardService, DashboardService>();
            //services.AddTransient<ICompaniesAPI, CompaniesAPI>();
            //services.AddTransient<IRuleOneAPI, RuleOneAPI
            services.AddSingleton<IMapper>(x => _mapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            app.UseInvSysLocalization(Configuration);
            app.UseInvSysLogger(Configuration, loggerFactory);
            app.UseInvSysOAuth(Configuration);
            app.UseMvc();
        }
    }
}
