using HealthEndpoint.Results;

namespace HealthEndpoint.Indicators
{
    public interface IHealthIndicator
    {
        HealthIndicatorResult Check();
    }
}
