using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Business.Commands;
public interface ICreateRestaurantCommand
{
    RestaurantId Execute(EntityName name, Address address, IEnumerable<Tag> tags, IEnumerable<OpeningHoursDay> openingHours);
}