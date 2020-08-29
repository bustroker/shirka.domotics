using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class GrafanaTests
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public GrafanaTests()
        {
            _environmentConfig = new EnvironmentConfiguration();
        }

        [Fact]
        public async Task GrafanaIsUp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.GrafanaBaseUrl);
                var response = await client.GetAsync("/api/health");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
