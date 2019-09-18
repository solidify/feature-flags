using System;
using System.Collections.Generic;
using System.Text;

namespace SolidifyLabs.FeatureFlags
{
    public class FeatureFlagService: IFeatureFlagService
    {
        private readonly IFeatureFlagProvider _provider;

        public FeatureFlagService(IFeatureFlagProvider provider)
        {
            _provider = provider;
        }

        public FeatureFlagValue<T> Is<T>() where T : FeatureFlag, new()
        {
            try
            {
                return new FeatureFlagValue<T>(_provider.IsEnabled(new T().Key));
            }
            catch (Exception e)
            {
                //Log e;
                return new FeatureFlagValue<T>(false);
            }
            
        }
    }

}
