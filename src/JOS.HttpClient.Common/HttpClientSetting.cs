using System;
using System.Net;
using System.Net.Http;

namespace JOSHttpClient.Common
{
    public static class HttpClientSetting
    {
        public static void SetDefaults(HttpClient c)
        {
            // run on every HttpClient created
            c.BaseAddress = new Uri(GitHubConstants.ApiBaseUrl);
            c.DefaultRequestHeaders.Add("Accept", "application/json");
            // c.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            c.DefaultRequestHeaders.Add("Accept-Encoding", "br");
            c.Timeout = TimeSpan.FromSeconds(5);
        }

        public static HttpMessageHandler ConfigureHandler()
        {
            // run once
            return new SocketsHttpHandler
            {
                MaxConnectionsPerServer = 50,
                PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5),
                AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.GZip,
                UseCookies = false,
            };
        }
    }
}