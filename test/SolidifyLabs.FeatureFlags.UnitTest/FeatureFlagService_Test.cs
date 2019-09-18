using System;
using AutoFixture;
using NSubstitute;
using NUnit.Framework;

namespace SolidifyLabs.FeatureFlags.UnitTest
{
    public class FeatureFlagService_Test
    {
        [Test]
        public void When_calling_feature_flag_service_Then_expected_result_is_returned()
        {
            var fixture = new Fixture();
            
            var provider = fixture.Freeze<IFeatureFlagProvider>();
            provider.IsEnabled(Arg.Any<string>()).Returns(true);
            var sut = fixture.Create<IFeatureFlagService>();
            var isEnabled = sut.Is<TestFeatureFlag>().Enabled;

            Assert.That(isEnabled);
        }



        public class TestFeatureFlag : FeatureFlag
        {
            public override string Key => "key1";
        }

    }
}
