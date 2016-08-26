using InvSys.Shared.Api.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.Swagger.Model;

namespace InvSys.Shared.Api.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInvSys(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddInvSysLocalization();
            services.AddInvSysConfiguration(configuration);
            services.AddMvc().AddDataAnnotationsLocalization();
            services.AddInvSysSwagger(configuration);
            services.AddInvSysAuthorization();
        }

        public static void AddInvSysLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
        }

        public static void AddInvSysConfiguration(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(configuration);
        }

        public static void AddInvSysSwagger(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = configuration["Swagger:Version"],
                     Title = configuration["Swagger:Title"],
                     Description = configuration["Swagger:Description"],
                     TermsOfService = configuration["Swagger:TermsOfService"]
                 })
            );
        }

        public static void AddInvSysAuthorization(this IServiceCollection services)
        {
            // Custom policy-based authorization
            services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy => policy.Requirements.Add(new RoleRequirement("Admin")))
            );
            services.AddSingleton<IAuthorizationHandler, RoleHandler>();
        }
    }
}
