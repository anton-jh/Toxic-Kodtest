using System.Text.Json.Serialization;

namespace RestaurantChooser.Api.Model;

public class OpeningHoursResponse
{
    public OpeningHoursResponse(DayOfWeek dayOfWeek, TimeOnly openingTime, TimeOnly closingTime)
    {
        DayOfWeek = dayOfWeek.ToString();
        OpeningTime = openingTime.ToString();
        ClosingTime = closingTime.ToString();
    }

    public string DayOfWeek { get; }
    public string OpeningTime { get; }
    public string ClosingTime { get; }
}
