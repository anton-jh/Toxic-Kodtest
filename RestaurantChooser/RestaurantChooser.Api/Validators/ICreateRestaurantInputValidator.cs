using RestaurantChooser.Api.Model;

namespace RestaurantChooser.Api.Validators;
public interface ICreateRestaurantInputValidator
{
    void EnsureValid(CreateRestaurantInput input);
}