﻿using System.Collections.Generic;

namespace HealthEndpoint.Results
{
    public class HealthCheckResult
    {
        public ICollection<HealthIndicatorResult> Indicators { get; set; } = new List<HealthIndicatorResult>();
    }
}
