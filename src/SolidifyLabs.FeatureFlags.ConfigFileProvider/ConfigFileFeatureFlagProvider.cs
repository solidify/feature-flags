using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.Extensions.Options;

namespace SolidifyLabs.FeatureFlags.ConfigFileProvider
{
    public class ConfigFileFeatureFlagProvider : IFeatureFlagProvider
    {
        private readonly Dictionary<string, bool> _configSource;

        public ConfigFileFeatureFlagProvider(IOptions<Dictionary<string, bool>> configSource)
        {
            _configSource = configSource.Value;
        }

        public bool IsEnabled(string featureFlagKey)
        {
            if (_configSource.TryGetValue(featureFlagKey, out var enabled))
            {
                return enabled;
            }

            return false;
        }
    }
}
