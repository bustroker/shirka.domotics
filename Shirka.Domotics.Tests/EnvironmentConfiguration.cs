using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Shirka.Domotics.Tests
{
    public class EnvironmentConfiguration
    {
        private readonly string _reverseProxyBaseUrl;
        private readonly string _reverseProxyNoderedPort;
        private readonly string _reverseProxyGrafanaPort;

        public EnvironmentConfiguration()
        {
            _reverseProxyBaseUrl = Environment.GetEnvironmentVariable("REVERSE_PROXY_BASE_URL");
            _reverseProxyNoderedPort = Environment.GetEnvironmentVariable("REVERSE_PROXY_NODE_PORT");
            _reverseProxyGrafanaPort = Environment.GetEnvironmentVariable("REVERSE_PROXY_GRAFANA_PORT");
        }

        public string NoderedBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{_reverseProxyNoderedPort}";

        public string GrafanaBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{_reverseProxyGrafanaPort}";

    }
}
