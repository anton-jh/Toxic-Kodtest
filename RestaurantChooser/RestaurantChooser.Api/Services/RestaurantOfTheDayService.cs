using RestaurantChooser.Api.Model;
using RestaurantChooser.Business.Commands;

namespace RestaurantChooser.Api.Services;

public class RestaurantOfTheDayService : IRestaurantOfTheDayService
{
    private readonly IPickRandomRestaurantCommand _pickRandomRestaurantCommand;


    public RestaurantOfTheDayService(IPickRandomRestaurantCommand pickRandomRestaurantCommand)
    {
        _pickRandomRestaurantCommand = pickRandomRestaurantCommand;
    }


    public RestaurantResponse PickRandom()
    {
        return new(_pickRandomRestaurantCommand.Execute());
    }
}
