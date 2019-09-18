using AutoFixture;
using NUnit.Framework;

namespace SolidifyLabs.FeatureFlags.UnitTest
{
    [TestFixture]
    public class FeatureFlagProvider_Test
    {
        [Test]
        public void When_creating_a_provider_Then_value_is_returned_as_expected()
        {
            var fixture = new Fixture();
            var key = fixture.Create<string>();
            var provider = new TestProvider(key);

            Assert.That(provider.IsEnabled(key));
            Assert.That(provider.IsEnabled(fixture.Create<string>()), Is.False);
        }

        public class TestProvider : IFeatureFlagProvider
        {
            private readonly string _enabledKey;

            public TestProvider(string enabledKey)
            {
                _enabledKey = enabledKey;
            }

            public bool IsEnabled(string featureFlagKey)
            {
                return featureFlagKey == _enabledKey;
            }
        }
    }
}