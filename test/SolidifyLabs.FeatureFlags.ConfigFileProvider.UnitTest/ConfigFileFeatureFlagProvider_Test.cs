using System.Collections.Generic;
using AutoFixture;
using Microsoft.Extensions.Options;
using NSubstitute;
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

            var dictionary = new Dictionary<string, bool>()
            {
                {"Key1", false},
                {"Key2", true}
            };
            var options = Substitute.For<IOptions<Dictionary<string, bool>>>();
            options.Value.Returns(dictionary);
            fixture.Inject(options);
            var sut = fixture.Create<ConfigFileFeatureFlagProvider>();
            Assert.Multiple(() =>
            {
                var result = sut.IsEnabled("Key1");
                Assert.That(result, Is.False);
                var result2 = sut.IsEnabled("Key2");
                Assert.That(result2);
                var result3 = sut.IsEnabled("Finnes ikke");
                Assert.That(result3, Is.False);
            });
          
        }
    }
}