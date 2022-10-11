using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Business.DataAccess;
public interface ICreateRestaurantDataAccess
{
    void AddAndSaveChanges(Restaurant restaurant);
    IEnumerable<Tag> GetTags();
    bool IsNameTaken(EntityName name);
}