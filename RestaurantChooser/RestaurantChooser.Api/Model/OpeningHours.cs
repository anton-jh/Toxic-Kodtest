namespace RestaurantChooser.Api.Model;

public class OpeningHours
{
    public DayOfWeek DayOfWeek { get; }
    public TimeOnly OpeningTime { get; }
    public TimeOnly ClosingTime { get; }
}