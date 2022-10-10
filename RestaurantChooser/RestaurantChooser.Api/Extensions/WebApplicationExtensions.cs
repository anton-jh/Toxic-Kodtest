using RestaurantChooser.Api.EndpointDefinitions;

namespace RestaurantChooser.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static WebApplication FromEndpointDefinitions<TDefinitions>(this WebApplication app)
        where TDefinitions : IEndpointDefinitions, new()
    {
        TDefinitions definitions = new();

        definitions.MapEndpoints(app);

        return app;
    }
}
