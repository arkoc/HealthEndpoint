using System;
using HealthEndpoint.Results;
using System.IO;
using System.Linq;

namespace HealthEndpoint.Indicators
{
    internal class DiskSpaceUsageIndicatorResult
    {
        public double TotalDiskSpaceInGB { get; set; }
        public double DiskSpaceUsageInGB { get; set; }
        public double UsageInPercentage { get; set; }
    }
    internal class DiskSpaceUsageIndicator : IHealthIndicator
    {
        private string _indicatorName = "Disk Space Usage";
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

            double usageInPresentage = (diskSpaceUsageInGB / totalDiskSpaceInGB) * 100;

            return new HealthIndicatorResult(_indicatorName)
            {
                Result = new DiskSpaceUsageIndicatorResult
                {
                    TotalDiskSpaceInGB = totalDiskSpaceInGB,
                    DiskSpaceUsageInGB = diskSpaceUsageInGB,
                    UsageInPercentage = usageInPresentage
                }
            };
        }
    }
}
