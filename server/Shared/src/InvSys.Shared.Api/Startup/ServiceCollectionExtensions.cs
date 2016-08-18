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
            // Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Configuration
            services.AddSingleton(configuration);

            // MVC
            services.AddMvc()
                .AddDataAnnotationsLocalization();

            // Swagger
            services.AddSwaggerGen(c =>
                 c.SingleApiVersion(new Info
                 {
                     Version = configuration["Swagger:Version"],
                     Title = configuration["Swagger:Title"],
                     Description = configuration["Swagger:Description"],
                     TermsOfService = configuration["Swagger:TermsOfService"]
                 })
            );

            // Custom policy-based authorization
            services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy => policy.Requirements.Add(new RoleRequirement("Admin")))
            );
            services.AddSingleton<IAuthorizationHandler, RoleHandler>();
        }
    }
}
