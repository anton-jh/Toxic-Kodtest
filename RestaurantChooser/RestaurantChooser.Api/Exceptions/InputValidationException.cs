namespace RestaurantChooser.Api.Exceptions;

public class InputValidationException : Exception
{
    public InputValidationException(string message)
        : base(message)
    {
    }
}
