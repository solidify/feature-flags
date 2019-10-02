using System;
using AutoFixture;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace SolidifyLabs.FeatureFlags.UnitTest
{
    public class FeatureFlagService_Test
    {
        [Test]
        public void When_calling_feature_flag_service_Then_expected_result_is_returned()
        {
            var fixture = new Fixture();
            var provider = Substitute.For<IFeatureFlagProvider>();
            provider.IsEnabled(Arg.Any<string>()).Returns(true);
            fixture.Inject(provider);
            var sut = fixture.Create<FeatureFlagService>();
            var isEnabled = sut.Is<TestFeatureFlag>().Enabled;

            Assert.That(isEnabled);
        }

        [Test]
        public void When_provider_throws_an_exeption_Then_is_enabled_defaults_to_false()
        {
            var fixture = new Fixture();
            var provider = Substitute.For<IFeatureFlagProvider>();
            fixture.Inject(provider);
            provider.IsEnabled(Arg.Any<string>()).Throws(new Exception("Boooom"));

            var sut = fixture.Create<FeatureFlagService>();

            var isEnabled = sut.Is<TestFeatureFlag>().Enabled;

            Assert.That(isEnabled, Is.False);
        }

        public class TestFeatureFlag : FeatureFlag
        {
            public override string Key => "key1";
        }

    }
}
