using HealthEndpoint.Results;
using System.Diagnostics;
using System.Threading;

namespace HealthEndpoint.Indicators
{
    internal class CpuUsageResult
    {
        public float TotalUsageInPercentage { get; set; }
    }

    internal class CpuUsageIndicator : IHealthIndicator
    {
        private string _indicatorName = "CPU Usage";
        public HealthIndicatorResult Check()
        {
            PerformanceCounter counter = new PerformanceCounter();
            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";
            var usage = counter.NextValue();
            Thread.Sleep(100);
            usage = counter.NextValue();

            return new HealthIndicatorResult(_indicatorName)
            {
                Result = new CpuUsageResult() { TotalUsageInPercentage = usage }
            };

        }
    }
}
