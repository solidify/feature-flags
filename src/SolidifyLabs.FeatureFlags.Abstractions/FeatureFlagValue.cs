namespace SolidifyLabs.FeatureFlags
{
    public class FeatureFlagValue<T> where T : FeatureFlag, new()
    {

        public FeatureFlagValue(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { get; }
    }
}