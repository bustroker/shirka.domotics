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
        private readonly string _directNoderedPort;
        private readonly string _directGrafanaPort;

        public EnvironmentConfiguration()
        {
            _reverseProxyBaseUrl = Environment.GetEnvironmentVariable("REVERSE_PROXY_BASE_URL");
            _reverseProxyNoderedPort = Environment.GetEnvironmentVariable("REVERSE_PROXY_NODE_PORT");
            _reverseProxyGrafanaPort = Environment.GetEnvironmentVariable("REVERSE_PROXY_GRAFANA_PORT");
            _directNoderedPort = Environment.GetEnvironmentVariable("DIRECT_NODERED_PORT");
            _directGrafanaPort = Environment.GetEnvironmentVariable("DIRECT_GRAFANA_PORT");
        }

        public string NoderedBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{_reverseProxyNoderedPort}";

        public string GrafanaBaseUrlThroughReverseProxy => $"{_reverseProxyBaseUrl}:{_reverseProxyGrafanaPort}";

        public string NoderedBaseUrl => $"{_reverseProxyBaseUrl}:{_directNoderedPort}";

        public string GrafanaBaseUrl => $"{_reverseProxyBaseUrl}:{_directGrafanaPort}";

    }
}
