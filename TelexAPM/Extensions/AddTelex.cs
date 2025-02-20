using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TelexApm.Services;

namespace TelexApm.Extensions;

public static class TelexServiceCollectionExtensions
{
    public static IServiceCollection AddTelex(this IServiceCollection services, IConfiguration Configuration)
    {
        var webhookChannelId = Configuration["Telex:ChannelHookId"];
        var baseUrl = Configuration["Telex:BaseUrl"];

        TelexConfiguration telexContainerConfig = new TelexConfiguration
        {
            ChannelHookId = webhookChannelId,
            BaseUrl = baseUrl
        };

        services.AddSingleton<ITelexClient>(provider =>
        {
            var httpClient = provider.GetRequiredService<HttpClient>();
            return new TelexClient(telexContainerConfig);
        });

        return services;
    }
}