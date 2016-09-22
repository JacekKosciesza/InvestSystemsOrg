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
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader() // TODO: configure it
            );
            app.UseInvSysLocalization(configuration);
            app.UseInvSysLogger(configuration, loggerFactory);
            app.UseInvSysOAuth(configuration);
            app.UseMvc();
            app.UseInvSysSwagger();

            return app;
        }

        public static IApplicationBuilder UseInvSysLocalization(this IApplicationBuilder app, IConfigurationRoot configuration)
        {
            var supportedCultures =
                configuration["Globalization:SupportedCultures"].Split(';')
                    .Select(c => new CultureInfo(c.Trim()))
                    .ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(configuration["Globalization:DefaultCulture"]),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            return app;
        }

        public static IApplicationBuilder UseInvSysLogger(this IApplicationBuilder app, IConfigurationRoot configuration, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            return app;
        }

        public static IApplicationBuilder UseInvSysOAuth(this IApplicationBuilder app, IConfigurationRoot configuration)
        {
            app.UseOAuthIntrospection(options =>
            {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.Authority = configuration["Authorization:OAuth:Introspection:Authority"];
                options.ClientId = configuration["Authorization:OAuth:Introspection:ClientId"];
                options.ClientSecret = configuration["Authorization:OAuth:Introspection:ClientSecret"];
            });

            return app;
        }

        public static IApplicationBuilder UseInvSysSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger((httpRequest, swaggerDoc) =>
            {
                swaggerDoc.Host = httpRequest.Host.Value;
            });
            app.UseSwaggerUi();

            return app;
        }
    }
}