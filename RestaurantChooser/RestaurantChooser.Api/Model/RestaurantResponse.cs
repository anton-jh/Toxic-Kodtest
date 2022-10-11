using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Api.Model;

public class RestaurantResponse
{
    public RestaurantResponse(Restaurant restaurant)
    {
        Id = restaurant.Id.Value;
        Name = restaurant.Name.Value;
        Address = restaurant.Address.Value;
        Tags = from Tag tag in restaurant.Tags
               select tag.Name;
        OpeningHours = from OpeningHoursDay hours in restaurant.OpeningHours
                       select new OpeningHoursResponse(hours);
    }


    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }
    public IEnumerable<string> Tags { get; }
    public IEnumerable<OpeningHoursResponse> OpeningHours { get; }
}
