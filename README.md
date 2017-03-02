# HealthEndpoint
Library for adding Health Checking HTTP Endpoint for services/components.

[![Build status](https://ci.appveyor.com/api/projects/status/6q7xxdogi4ltqr8o?svg=true)](https://ci.appveyor.com/project/arkoc/healthendpoint)

**current status: alpha**

## Overview ##

**HealthEndpoint** is a tool for developers to add health checking endpoint to their applications. This includes CPU, Memory, DiskSpace usage indicators.

## Usage ##

If you want to embed HealthEndpoint into your Web service or application, you can use HealthEndpoint NuGet package. NuGet package adds Endpoint to your Web component, so you only need to specify health indicators. Here is what you need to do.

* Create/Open a Web project
* Open Package Manager Console window and write the following command: 

`Install-Package HealthEndpoint`

Edit your `Startup.cs` class to add HealthEndpoint configuration and HealthIndicators.

```c#
public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var healthEndpointOptions = new HealthEndpointOptions();
        healthEndpointOptions
            .AddCpuUsageIndicator()
            .AddDiskSpaceUsageIndicator()
            .AddMemoryUsageIndicator();

        app.UseHealthEndpoint(healthEndpointOptions);
    }
}
```

This code will add new health endpoint to your application with default `.well-known/health-endpoint` route. (You can change it with `Route` property of `HealthEndpointOptions` class.

Also we are adding CPU, DiskSpace and MemoryUsage Indicators. And when we request for example `GET http://localhost/.well-known/health-endpoint` we will get following result:

```json
{
  "indicators": [
    {
      "name": "CPU Usage",
      "errors": [],
      "result": {
        "usagePercentage": 17.8920956
      }
    },
    {
      "name": "DiskSpace Usage",
      "errors": [],
      "result": {
        "totalDiskSpaceInGB": 237,
        "diskSpaceUsageInGB": 149,
        "usagePercentage": 62.8691983122363
      }
    },
    {
      "name": "Memory Usage",
      "errors": [],
      "result": {
        "totalMemoryInMB": 8192,
        "availableMemoryInMB": 483,
        "usagePercentage": 94.10400390625
      }
    }
  ]
}
```

## Note ##

The package is in active development. If you have any questions, suggestions or something related to this feel free to add Issue or contact me.
