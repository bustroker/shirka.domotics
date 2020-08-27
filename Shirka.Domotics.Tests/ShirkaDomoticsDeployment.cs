using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class ShirkaDomoticsDeployment
    {
        private const string NodeRedBaseUrl = "http://localhost:1880";

        [Fact]
        public async Task NodeRedIsUp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NodeRedBaseUrl);
                var response = await client.GetAsync("/health/nodered");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }

        [Fact]
        public async Task MosquittoIsUpAndAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NodeRedBaseUrl);
                var response = await client.GetAsync("/health/mosquitto");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
        
        [Fact]
        public async Task InfluxDbIsUpAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NodeRedBaseUrl);
                var response = await client.GetAsync("/health/influxdb");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
        
        [Fact]
        public async Task GrafanaIsUpAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NodeRedBaseUrl);
                var response = await client.GetAsync("/health/grafana");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
