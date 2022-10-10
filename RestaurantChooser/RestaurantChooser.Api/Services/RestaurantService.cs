using RestaurantChooser.Api.Model;
using RestaurantChooser.Data;
using RestaurantChooser.Domain.Entities;

namespace RestaurantChooser.Api.Services;

public class RestaurantService : IRestaurantService
{
    private readonly ApplicationDbContext _dbContext;


    public RestaurantService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IEnumerable<RestaurantResponse> GetAll()
    {
        return
            from Restaurant rest in _dbContext.Restaurants
            select new RestaurantResponse(
                rest.Id.Value,
                rest.Name.Value,
                rest.Address.Value,
                from Tag tag in rest.Tags select tag.Name.Value);
    }
}
