using Microsoft.AspNetCore.Mvc;
using RestaurantChooser.Api.Exceptions;
using RestaurantChooser.Api.Model;
using RestaurantChooser.Api.Services;
using RestaurantChooser.Api.Validators;
using RestaurantChooser.Business.Commands;
using RestaurantChooser.Business.DataAccess;
using RestaurantChooser.Business.Exceptions;
using RestaurantChooser.Domain.Exceptions;

namespace RestaurantChooser.Api.EndpointDefinitions;

internal class RestaurantEndpointDefinitions : IEndpointDefinitions
{
    public IEndpointDefinitions MapEndpoints(WebApplication app)
    {
        app.MapPost("/restaurants/", Create);
        app.MapGet("/restaurants/{id}", GetById);
        app.MapGet("/restaurants/", GetAll);

        return this;
    }

    public IEndpointDefinitions RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<ICreateRestaurantInputValidator, CreateRestaurantInputValidator>();
        services.AddScoped<ICreateRestaurantCommand, CreateRestaurantCommand>();
        services.AddScoped<ICreateRestaurantDataAccess, CreateRestaurantDataAccess>();

        return this;
    }


    public static IResult GetAll([FromServices] IRestaurantService restaurantService)
    {
        return Results.Json(restaurantService.GetAll());
    }

    public static IResult GetById([FromRoute]Guid id, [FromServices] IRestaurantService restaurantService)
    {
        try
        {
            return Results.Json(restaurantService.GetById(id));
        }
        catch (EntityNotFoundException)
        {
            return Results.NotFound();
        }
    }

    public static IResult Create([FromBody] CreateRestaurantInput input, [FromServices] IRestaurantService restaurantService)
    {
        try
        {
            return Results.Json(restaurantService.Create(input));
        }
        catch (NameTakenException)
        {
            return Results.BadRequest(new
            {
                Error = "Name is taken."
            });
        }
    }
}
