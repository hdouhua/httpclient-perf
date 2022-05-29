using JOSHttpClient.Common;
using Microsoft.Extensions.DependencyInjection;

namespace JOSHttpClient.Version4
{
    public static class Version4Configurator
    {
        public static void AddVersion4(this IServiceCollection services)
        {
            services.AddTransient<GetAllProjectsQuery>();
            services.AddHttpClient<GitHubClient>(HttpClientSetting.SetDefaults)
                .ConfigurePrimaryHttpMessageHandler(HttpClientSetting.ConfigureHandler);
        }
    }
}
