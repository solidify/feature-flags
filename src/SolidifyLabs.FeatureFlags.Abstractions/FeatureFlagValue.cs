namespace SolidifyLabs.FeatureFlags
{
    public class FeatureFlagValue<T> where T : FeatureFlag, new()
    {
        private readonly IFeatureFlagProvider _provider;

        public FeatureFlagValue(IFeatureFlagProvider provider)
        {
            _provider = provider;
        }

        public bool Enabled => _provider.IsEnabled(new T().Key);
    }
}