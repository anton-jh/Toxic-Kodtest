using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Api.Model;

public class RestaurantResponse
{
    public RestaurantResponse(Guid id, string name, string address, IEnumerable<string> tags)
    {
        Id = id;
        Name = name;
        Address = address;
        Tags = tags;
    }


    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }
    public IEnumerable<string> Tags { get; }
}
