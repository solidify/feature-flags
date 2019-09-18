using AutoFixture;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SolidifyLabs.FeatureFlags.UnitTest
{
    [TestFixture]
    public class FeatureFlagProvider_Test
    {
        [Test]
        public void When_creating_a_provider_Then()
        {
            var fixture = new Fixture();

            var provider = new TestProvider();


        }


        public class TestProvider : IFeatureFlagProvider
        {

        }
    }
}