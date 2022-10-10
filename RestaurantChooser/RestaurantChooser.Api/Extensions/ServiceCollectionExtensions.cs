using RestaurantChooser.Api.EndpointDefinitions;
using System.Runtime.CompilerServices;

namespace RestaurantChooser.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection FromEndpointDefinitions<TDefinitions>(this IServiceCollection services)
        where TDefinitions : IEndpointDefinitions, new()
    {
        TDefinitions definitions = new();

        definitions.RegisterServices(services);

        return services;
    }
}
