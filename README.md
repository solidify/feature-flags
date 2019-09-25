# feature-flags
[![Build Status](https://dev.azure.com/solidify/OSS/_apis/build/status/solidify.feature-flags?branchName=master)](https://dev.azure.com/solidify/OSS/_build/latest?definitionId=68&branchName=master)

# Solidify Feature Flags

## Enable Feature Flags with config file provider in a web api

Startup.cs:
```csharp


public void ConfigureServices(IServiceCollection services)
{
    ...
    services.Configure<Dictionary<string, bool>>(Configuration.GetSection("FeatureFlags"));
    services.AddSingleton<IFeatureFlagProvider, ConfigFileProvider.ConfigFileFeatureFlagProvider>();
    services.AddSingleton<IFeatureFlagService, FeatureFlagService>();
    ...
}

```
### Add new feature flag
To add a new feature flag we have to add a new entry in the config file. In this example we add a feature flag with the key "US101_AddNewIntegration"

appsettings.json:
```json
{
  "FeatureFlags": {
    "US101_ReturnNewValues": true,
  }
}
```
Note that the sections name must be the same as the one provided in Startup.cs

### Add a class for the feature flag
Add a new class that extends FeatureFlag.cs
```csharp
public class FFReturnNewValues : FeatureFlag
{
    public override string Key => "US101_ReturnNewValues";
}
```

### Use feature flag
A IFeatureFlagService is needed to check if a feature flag is active. The below example shows how to check if the feature flag FFReturnNewValues is active.
```csharp
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SolidifyLabs.FeatureFlags.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFeatureFlagService _featureFlagService;

        public ValuesController(IFeatureFlagService featureFlagService)
        {
            _featureFlagService = featureFlagService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if (_featureFlagService.Is<MyFlag>().Enabled)
            {
                return new string[] {"wow", "such feature"};
            }

            return new string[] { "value1", "value2" };
        }
    }
}
```
