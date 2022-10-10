using RestaurantChooser.Api.Model;

namespace RestaurantChooser.Api.Services;
public interface IRestaurantService
{
    IEnumerable<RestaurantResponse> GetAll();
}