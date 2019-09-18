namespace SolidifyLabs.FeatureFlags
{
    public interface IFeatureFlagProvider
    {
        bool IsEnabled(string featureFlagKey);
    }
}