using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class NginxTests
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public NginxTests()
        {
            _environmentConfig = new EnvironmentConfiguration();
        }

        [Fact]
        public async Task NodeRedIsUpThroughNginxReverseProxy()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/nodered");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }

        [Fact]
        public async Task GrafanaIsUpThroughNginxReverseProxy()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.GrafanaBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/api/health");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
