using RestaurantChooser.Api.Exceptions;

namespace RestaurantChooser.Api.Validators;

public abstract class InputValidator
{
    protected void PropertyRequiredThrowHelper(string propertyName, string? addon = null)
    {
        string ending = addon is not null ? $", {addon}" : ".";

        throw new InputValidationException($"Property '{propertyName}' is required{ending}");
    }
}
