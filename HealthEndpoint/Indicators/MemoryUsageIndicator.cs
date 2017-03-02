using System;
using HealthEndpoint.Results;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HealthEndpoint.Indicators
{
    internal class MemoryUsageIndicatorResult
    {
        public double TotalMemoryInMB { get; set; }
        public double AvailableMemoryInMB { get; set; }
        public double MemoryUsageInPercentage { get; set; }
    }

    internal class MemoryUsageIndicator : IHealthIndicator
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        private string _indicatorName = "Memory Usage";
        public HealthIndicatorResult Check()
        {
            var availableRAMCounter = new PerformanceCounter("Memory", "Available MBytes");
            double totalMemory = GetTotalMemmoryInMB();
            double availableMemory = availableRAMCounter.NextValue();

            double memUsageInPercentage = ((totalMemory - availableMemory) / totalMemory) * 100;

            return new HealthIndicatorResult(_indicatorName)
            {
                Result = new MemoryUsageIndicatorResult()
                {
                    TotalMemoryInMB = totalMemory,
                    AvailableMemoryInMB = availableMemory,
                    MemoryUsageInPercentage = memUsageInPercentage
                }
            };
        }

        private double GetTotalMemmoryInMB()
        {
            long totalMeminKb;
            GetPhysicallyInstalledSystemMemory(out totalMeminKb);
            return (double)totalMeminKb / 1024;
        }
    }
}
