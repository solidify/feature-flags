using AutoFixture;
using NUnit.Framework;

namespace SolidifyLabs.FeatureFlags.ConfigFileProvider.UnitTest
{
    [TestFixture]
    public class ConfigFileFeatureFlagProvider_Test
    {
        [Test]
        public void When_calling_IsEnabled_Then_the_expected_result_is_returned()
        {
            var fixture = new Fixture();

            var sut = fixture.Create<ConfigFileFeatureFlagProvider>();

            var result = sut.IsEnabled(fixture.Create<bool>());

            Assert.That(result);
        }
    }
}