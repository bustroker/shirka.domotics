using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class MosquittoTests
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public MosquittoTests()
        {
            _environmentConfig = new EnvironmentConfiguration();
        }

        [Fact]
        public async Task MosquittoIsUpAndAndNoderedCanConnectWithIt()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.NoderedBaseUrlThroughReverseProxy);
                var response = await client.GetAsync("/health/mosquitto");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
