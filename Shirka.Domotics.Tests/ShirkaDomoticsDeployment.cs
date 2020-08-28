using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class ShirkaDomoticsDeployment
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public ShirkaDomoticsDeployment()
        {
            var environmentName = Environment.GetEnvironmentVariable("ENVIRONMENT_NAME");
            switch (environmentName)
            {
                case "DEV": _environmentConfig = EnvironmentConfiguration.VagrantVM;
                case "PRE": _environmentConfig = EnvironmentConfiguration.RaspberryPi;
                default: throw new ArgumentException($"Unknown environment ENVIRONMENT_NAME={environmentName}. Needs to be either 'DEV' or 'PRE'.");
            }
        }

        [Fact]
        public async Task NodeRedIsUpThroughNginxReverseProxy()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/nodered");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }

        [Fact]
        public async Task MosquittoIsUpAndAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/mosquitto");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }

        [Fact]
        public async Task InfluxDbIsUpAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/influxdb");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }

        [Fact]
        public async Task GrafanaIsUpThroughNginxReverseProxy()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GrafanaBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/api/health");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
