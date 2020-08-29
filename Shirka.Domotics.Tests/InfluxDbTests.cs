using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class InfluxDbTests
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public InfluxDbTests()
        {
            _environmentConfig = new EnvironmentConfiguration();
        }

        [Fact]
        public async Task InfluxDbIsUpAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/influxdb");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
