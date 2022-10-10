using Microsoft.AspNetCore.Mvc;
using RestaurantChooser.Api.Services;

namespace RestaurantChooser.Api.EndpointDefinitions;

internal class RestaurantEndpointDefinitions : IEndpointDefinitions
{
    public IEndpointDefinitions MapEndpoints(WebApplication app)
    {
        app.MapGet("/restaurants/", GetAll);

        return this;
    }

    public IEndpointDefinitions RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IRestaurantService, RestaurantService>();

        return this;
    }


    public static IResult GetAll([FromServices] IRestaurantService restaurantService)
    {
        return Results.Json(restaurantService.GetAll());
    }
}
