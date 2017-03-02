using HealthEndpoint.Configuration;
using HealthEndpoint.Indicators;
using System;

namespace HealthEndpoint.Extensions
{
    public static class HealthEndpointOptionsExtensions
    {
        public static HealthEndpointOptions AddCpuUsageIndicator(this HealthEndpointOptions options)
        {
            Ensure.NotNull(options, nameof(options));
            options.AddIndicator(new CpuUsageIndicator());
            return options;
        }

        public static HealthEndpointOptions AddMemoryUsageIndicator(this HealthEndpointOptions options)
        {
            Ensure.NotNull(options, nameof(options));
            options.AddIndicator(new MemoryUsageIndicator());
            return options;
        }

        public static HealthEndpointOptions AddDiskSpaceUsageIndicator(this HealthEndpointOptions options)
        {
            Ensure.NotNull(options, nameof(options));
            options.AddIndicator(new DiskSpaceUsageIndicator());
            return options;
        }
    }
}
