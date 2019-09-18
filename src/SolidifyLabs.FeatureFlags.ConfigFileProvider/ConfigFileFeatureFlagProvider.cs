using System;

namespace SolidifyLabs.FeatureFlags.ConfigFileProvider
{
    public class ConfigFileFeatureFlagProvider : IFeatureFlagProvider
    {
        public ConfigFileFeatureFlagProvider()
        {
        }

        public bool IsEnabled(bool featureFlagKey)
        {
            throw new NotImplementedException();
        }
    }
}
