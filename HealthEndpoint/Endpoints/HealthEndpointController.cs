using HealthEndpoint.Configuration;
using HealthEndpoint.Results;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace HealthEndpoint.Endpoints
{
    public sealed class HealthEndpointController : ApiController
    {
        private HealthEndpointOptions _options;

        public HealthEndpointController(HealthEndpointOptions options)
        {
            Ensure.NotNull(options, nameof(options));
            _options = options;
        }

        [HttpGet]
        [ResponseType(typeof(HealthCheckResult))]
        public IHttpActionResult CheckHealth()
        {
            var healthCheckResult = new HealthCheckResult();

            foreach (var indicator in _options.Indicators)
            {
                var indicatorResult = indicator.Check();
                if (indicatorResult != null)
                {
                    healthCheckResult.IndicatorResults.Add(indicatorResult);
                }
            }

            return Ok(healthCheckResult);
        }
    }
}
