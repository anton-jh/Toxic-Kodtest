using Microsoft.AspNetCore.Mvc;
using RestaurantChooser.Api.Services;
using RestaurantChooser.Business.Commands;
using RestaurantChooser.Business.DataAccess;
using RestaurantChooser.Business.Interfaces;

namespace RestaurantChooser.Api.EndpointDefinitions;

internal class RestaurantOfTheDayEnpointDefinitions : IEndpointDefinitions
{
    public IEndpointDefinitions MapEndpoints(WebApplication app)
    {
        app.MapGet("/restaurant-of-the-day/", GetRestaurantOfTheDay);

        return this;
    }

    public IEndpointDefinitions RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IRandomProvider, DefaultRandomProvider>();

        services.AddScoped<IPickRandomRestaurantCommand, PickRandomRestaurantCommand>();
        services.AddScoped<IPickRandomRestaurantDataAccess, PickRandomRestaurantDataAccess>();
        services.AddScoped<IRestaurantOfTheDayService, RestaurantOfTheDayService>();

        return this;
    }


    private IResult GetRestaurantOfTheDay([FromServices] IRestaurantOfTheDayService restaurantOfTheDayService)
    {
        return Results.Json(restaurantOfTheDayService.PickRandom());
    }
}
