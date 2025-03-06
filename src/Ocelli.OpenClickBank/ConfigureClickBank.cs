using Microsoft.Extensions.DependencyInjection;

namespace Ocelli.OpenClickBank;

public static class ConfigureClickBank
{
    /// <summary>
    /// Registers ClickBank services, including HttpClientFactory and the ClickBankService factory.
    /// </summary>
    public static IServiceCollection AddClickBankServices(this IServiceCollection services)
    {
        services.AddHttpClient("ClickBankClient")
            .ConfigureHttpClient(client => client.Timeout = TimeSpan.FromSeconds(30));

        services.AddSingleton<IClickBankServiceFactory, ClickBankServiceFactory>();

        // Optionally, allow injecting ClickBankService directly
        services.AddTransient<IClickBankService>(sp =>
        {
            var factory = sp.GetRequiredService<IClickBankServiceFactory>();
            var defaultConfig = new OpenClickBankConfig(); // Provide sensible defaults
            return factory.Create(defaultConfig);
        });

        return services;
    }

    /// <summary>
    /// Registers ClickBank services and allows passing a preconfigured OpenClickBankConfig.
    /// </summary>
    public static IServiceCollection AddClickBankServices(this IServiceCollection services, OpenClickBankConfig config)
    {
        services.AddClickBankServices(); // Register base services

        // Register ClickBankService with user-provided configuration
        services.AddTransient<IClickBankService>(sp =>
        {
            var factory = sp.GetRequiredService<IClickBankServiceFactory>();
            return factory.Create(config);
        });

        return services;
    }
}