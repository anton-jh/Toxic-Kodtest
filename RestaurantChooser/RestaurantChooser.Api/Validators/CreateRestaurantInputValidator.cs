using RestaurantChooser.Api.Exceptions;
using RestaurantChooser.Api.Model;

namespace RestaurantChooser.Api.Validators;

public class CreateRestaurantInputValidator : InputValidator, ICreateRestaurantInputValidator
{
    public void EnsureValid(CreateRestaurantInput input)
    {
        if (input.Name is null)
        {
            PropertyRequiredThrowHelper(nameof(input.Name));
        }
        if (input.Address is null)
        {
            PropertyRequiredThrowHelper(nameof(input.Address));
        }
        if (input.OpeningHours is null || input.OpeningHours.Any() == false)
        {
            PropertyRequiredThrowHelper(nameof(input.OpeningHours), "List cannot be empty.");
        }
    }
}
