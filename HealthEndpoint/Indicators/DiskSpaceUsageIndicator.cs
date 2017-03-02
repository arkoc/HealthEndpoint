using System;
using HealthEndpoint.Results;
using System.IO;
using System.Linq;

namespace HealthEndpoint.Indicators
{
    internal class DiskSpaceUsageIndicatorResult
    {
        public decimal TotalDiskSpaceInGB { get; set; }
        public decimal DiskSpaceUsageInGB { get; set; }
        public decimal UsagePercentage { get; set; }
    }
    internal class DiskSpaceUsageIndicator : IHealthIndicator
    {
        private string _indicatorName = "DiskSpace Usage";
        public HealthIndicatorResult Check()
        {
            DriveInfo[] oDrvs = DriveInfo.GetDrives();
            var drives = DriveInfo.GetDrives().Where(x => x.IsReady && x.DriveType == DriveType.Fixed);
            double totalDiskSpaceInGB = 0;
            double diskSpaceUsageInGB = 0;

            foreach (var drive in drives)
            {
                totalDiskSpaceInGB += drive.TotalSize / 1024 / 1024 / 1024; // in GB
                diskSpaceUsageInGB += drive.AvailableFreeSpace / 1024 / 1024 / 1024; // in GB
            }

            double usageInPresentage = totalDiskSpaceInGB != 0 ? (diskSpaceUsageInGB / totalDiskSpaceInGB) * 100 : 0;

            return new HealthIndicatorResult(_indicatorName)
            {
                Result = new DiskSpaceUsageIndicatorResult
                {
                    TotalDiskSpaceInGB = (decimal)totalDiskSpaceInGB,
                    DiskSpaceUsageInGB = (decimal)diskSpaceUsageInGB,
                    UsagePercentage = (decimal)usageInPresentage
                }
            };
        }
    }
}
