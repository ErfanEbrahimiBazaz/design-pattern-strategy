using Microsoft.Extensions.DependencyInjection;
using Strategy.Business.Strategies.Payment;
using Strategy.Services;


namespace Strategy;

public static class DependencyExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<OrderService>();
        services.AddScoped<IPaymentStrategy, CreditCardPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, PaypalPaymentStrategy>();
        return services;
    }

    // bad practice, provider must be created once at the composition root. This encourages multiple provider misuse, memory leak and scoped service issues.
    //public static ServiceProvider AddProviders(this ServiceCollection services)
    //{
    //    var providers = services.BuildServiceProvider();
    //    return providers;
    //}

}
