namespace RestaurantChooser.Api.EndpointDefinitions;

internal interface IEndpointDefinitions
{
    IEndpointDefinitions MapEndpoints(WebApplication app);

    IEndpointDefinitions RegisterServices(IServiceCollection services);
}
