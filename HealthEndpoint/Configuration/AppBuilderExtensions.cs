using Owin;
using System;

namespace HealthEndpoint.Configuration
{
    public static class AppBuilderExtensions
    {
        public static void UseHealthEndpoint(this IAppBuilder app, HealthEndpointOptions options)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (options == null) throw new ArgumentNullException(nameof(options));

            app.UseWebApi(WebApiConfig.Configure(options));
        }
    }
}
