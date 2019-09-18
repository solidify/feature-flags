namespace SolidifyLabs.FeatureFlags
{
    public interface IFeatureFlagService
    {
        FeatureFlagValue<T> Is<T>() where T : FeatureFlag;
    }
}