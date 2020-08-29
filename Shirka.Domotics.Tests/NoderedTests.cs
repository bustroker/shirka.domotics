using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class NoderedTests
    {
        private readonly EnvironmentConfiguration _environmentConfig;
        public NoderedTests()
        {
            _environmentConfig = new EnvironmentConfiguration();
        }

        [Fact]
        public async Task NodeRedIsUp()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_environmentConfig.NoderedBaseUrl);
                var response = await client.GetAsync("/health/nodered");
                response.IsSuccessStatusCode.Should().BeTrue();
            }
        }
    }
}
