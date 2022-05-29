using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version3
{
    public static class Version3Configurator
    {
        public static void AddVersion3(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProjectsQuery>();
            services.AddHttpClient("GitHub.Version3", HttpClientSetting.SetDefaults)
                .ConfigurePrimaryHttpMessageHandler(HttpClientSetting.ConfigureHandler);
            services.AddSingleton<GitHubClient>();
        }
    }
}
