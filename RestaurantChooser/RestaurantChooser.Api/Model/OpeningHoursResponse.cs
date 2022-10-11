using RestaurantChooser.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace RestaurantChooser.Api.Model;

public class OpeningHoursResponse
{
    public OpeningHoursResponse(OpeningHoursDay hours)
    {
        DayOfWeek = hours.DayOfWeek.ToString();
        OpeningTime = hours.OpeningTime.ToString();
        ClosingTime = hours.ClosingTime.ToString();
    }

    public string DayOfWeek { get; }
    public string OpeningTime { get; }
    public string ClosingTime { get; }
}
