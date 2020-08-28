using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class ShirkaDomoticsDeployment
    {
        private const string ReverseProxyBaseUrl = "http://192.168.1.102"; //"http://localhost"; // either raspberry IP or localhost when in VM
        private const string ReverseProxyNoderedPort = "8080";
        private const string ReverseProxyGrafanaPort = "9090";

        private static string NoderedBaseUrlThroughReverseProxy =>  $"{ReverseProxyBaseUrl}:{ReverseProxyNoderedPort}";
        private static string GrafanaBaseUrlThroughReverseProxy => $"{ReverseProxyBaseUrl}:{ReverseProxyGrafanaPort}";

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
