using RestaurantChooser.Api.Exceptions;
using System;
using System.Text.Json.Serialization;

namespace RestaurantChooser.Api.Model;

public class OpeningHoursInput
{
    [JsonConstructor]
    public OpeningHoursInput(string dayOfWeek, string openingTime, string closingTime)
    {
        DayOfWeek = dayOfWeek;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
    }

    public string DayOfWeek { get; private set; }
    public string OpeningTime { get; private set; }
    public string ClosingTime { get; private set; }
}