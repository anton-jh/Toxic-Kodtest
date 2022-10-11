using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Business.DataAccess;
public interface ICreateRestaurantDataAccess
{
    void AddAndSaveChanges(Restaurant restaurant);
    bool IsNameTaken(EntityName name);
}