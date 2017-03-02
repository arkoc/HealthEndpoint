using System.Collections.Generic;

namespace HealthEndpoint.Results
{
    public class HealthCheckResult
    {
        public ICollection<HealthIndicatorResult> IndicatorResults { get; set; } = new List<HealthIndicatorResult>();
    }
}
