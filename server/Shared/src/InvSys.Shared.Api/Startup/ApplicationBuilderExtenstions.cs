using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Linq;

namespace InvSys.Shared.Api.Startup
{
    public static class ApplicationBuilderExtenstions
    {
        public static IApplicationBuilder UseInvSys(this IApplicationBuilder app, IConfigurationRoot configuration, ILoggerFactory loggerFactory)
        {
            var supportedCultures = configuration["Globalization:SupportedCultures"].Split(';').Select(c => new CultureInfo(c.Trim())).ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(configuration["Globalization:DefaultCulture"]),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseOAuthIntrospection(options => {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.Authority = configuration["Authorization:OAuth:Introspection:Authority"];
                options.ClientId = configuration["Authorization:OAuth:Introspection:ClientId"];
                options.ClientSecret = configuration["Authorization:OAuth:Introspection:ClientSecret"];
            });
            app.UseMvc();

            // Swagger
            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi();

            return app;
        }
    }
}
