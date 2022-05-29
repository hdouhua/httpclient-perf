using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version10
{
    public static class Version10Configurator
    {
        public static void AddVersion10(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient<GitHubClient>("GitHubClient.Version10", HttpClientSetting.SetDefaults)
                .ConfigurePrimaryHttpMessageHandler(HttpClientSetting.ConfigureHandler);
            services.AddSingleton<GitHubClientFactory>();
            services.AddSingleton<Utf8JsonSerializer>();
        }
    }
}
