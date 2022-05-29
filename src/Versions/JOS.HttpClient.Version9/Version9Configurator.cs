using System;
using System.Linq;
using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace JOSHttpClient.Version9
{
    public static class Version9Configurator
    {
        public static void AddVersion9(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient<GitHubClient>("GitHubClient.Version9", HttpClientSetting.SetDefaults)
                .ConfigurePrimaryHttpMessageHandler(HttpClientSetting.ConfigureHandler);
            services.AddSingleton<GitHubClientFactory>();
            
            // remove some HandlerDelegate
            services.Where(s => s.ServiceType == typeof(IHttpMessageHandlerBuilderFilter)).ToList().ForEach(it => {
                services.Remove(it);
            });
        }
    }
}