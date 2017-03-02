using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using HealthEndpoint.Configuration;
using HealthEndpoint.Extensions;

[assembly: OwinStartup(typeof(HealthEndpoint.Host.Startup))]

namespace HealthEndpoint.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var healthEndpointOptions = new HealthEndpointOptions();
            healthEndpointOptions
                .AddCpuUsageIndicator()
                .AddDiskSpaceUsageIndicator()
                .AddMemoryUsageIndicator();

            app.UseHealthEndpoint(healthEndpointOptions);
        }
    }
}
