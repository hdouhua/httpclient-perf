using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version5
{
    public static class Version5Configurator
    {
        public static void AddVersion5(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient<GitHubClient>("GitHubClient.Version5", HttpClientSetting.SetDefaults)
                .ConfigurePrimaryHttpMessageHandler(HttpClientSetting.ConfigureHandler);
            services.AddSingleton<GitHubClientFactory>();
        }
    }
}
