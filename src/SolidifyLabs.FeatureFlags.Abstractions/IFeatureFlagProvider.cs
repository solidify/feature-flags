namespace SolidifyLabs.FeatureFlags
{
    public interface IFeatureFlagProvider
    {
        bool IsEnabled(bool featureFlagKey);
    }
}