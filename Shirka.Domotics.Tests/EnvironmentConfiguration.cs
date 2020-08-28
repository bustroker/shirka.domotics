using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class EnvironmentConfiguration
    {
        private const string reverseProxyNoderedPort = "8080";
        private const string reverseProxyGrafanaPort = "9090";
        private readonly string _reverseProxyBaseUrl;
        private EnvironmentConfiguration(string reverseProxyBaseUrl)
        {
            _reverseProxyBaseUrl = reverseProxyBaseUrl;
        }

        public string NoderedBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{reverseProxyNoderedPort}";

        public string GrafanaBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{reverseProxyGrafanaPort}";

        public static EnvironmentConfiguration VagrantVM => new EnvironmentConfiguration(reverseProxyBaseUrl = "http://localhost");

        public static EnvironmentConfiguration RaspberryPi => new EnvironmentConfiguration(reverseProxyBaseUrl = "http://192.168.1.102");

    }
}
