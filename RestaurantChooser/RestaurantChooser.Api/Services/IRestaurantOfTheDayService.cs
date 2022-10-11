using RestaurantChooser.Api.Model;

namespace RestaurantChooser.Api.Services;
public interface IRestaurantOfTheDayService
{
    RestaurantResponse PickRandom();
}