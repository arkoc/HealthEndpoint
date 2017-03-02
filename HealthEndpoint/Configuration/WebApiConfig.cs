using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Web.Http;

namespace HealthEndpoint.Configuration
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Configure(HealthEndpointOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var config = new HttpConfiguration();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "HealthEndpoint",
                routeTemplate: options.Route,
                defaults: new { controller = "HealthEndpoint", action = "CheckHealth" }
            );

            ConfigureIoC(config, options);

            return config;
        }

        public static void ConfigureIoC(HttpConfiguration config, HealthEndpointOptions options)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            builder.RegisterInstance(options);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
