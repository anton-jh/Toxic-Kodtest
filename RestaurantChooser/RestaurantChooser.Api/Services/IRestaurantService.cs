using RestaurantChooser.Api.Model;

namespace RestaurantChooser.Api.Services;
public interface IRestaurantService
{
    CreateRestaurantResponse Create(CreateRestaurantInput input);
    IEnumerable<RestaurantResponse> GetAll();
}