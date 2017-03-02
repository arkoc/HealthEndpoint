using HealthEndpoint.Indicators;
using System;
using System.Collections.Generic;

namespace HealthEndpoint.Configuration
{
    public static class HealthEndpointOptionsExtensions
    {
        public static HealthEndpointOptions AddIndicator(this HealthEndpointOptions opts, IHealthIndicator indicator)
        {
            Ensure.NotNull(opts, nameof(opts));
            Ensure.NotNull(indicator, nameof(indicator));

            opts.Indicators.Add(indicator);

            return opts;
        }
    }

    public class HealthEndpointOptions
    {
        public HealthEndpointOptions()
        {
            Route = Constants.WellKnownHealthRoute;
            Indicators = new List<IHealthIndicator>();
        }

        public string Route { get; set; }
        internal ICollection<IHealthIndicator> Indicators { get; set; }
    }
}
