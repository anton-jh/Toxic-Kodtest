using RestaurantChooser.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RestaurantChooser.Domain.ValueObjects;

/// <summary>
/// An object representing opening and closing times for a specific day of the week.
/// </summary>
public class OpeningHoursDay
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="dayOfWeek">The day of the week this object represents.</param>
    /// <param name="openingTime">Opening time.</param>
    /// <param name="closingTime">Closing time.</param>
    /// <exception cref="DomainValidationException"></exception>
    public OpeningHoursDay(DayOfWeek dayOfWeek, TimeOnly openingTime, TimeOnly closingTime)
    {
        DayOfWeek = dayOfWeek;
        OpeningTime = openingTime;
        ClosingTime = closingTime;

        EnsureValidTimes();
    }


    /// <summary>
    /// The day of the week this object represents.
    /// </summary>
    public DayOfWeek DayOfWeek { get; }

    /// <summary>
    /// Opening time.
    /// </summary>
    public TimeOnly OpeningTime { get; }

    /// <summary>
    /// Closing time.
    /// </summary>
    public TimeOnly ClosingTime { get; }


    public override bool Equals(object? obj)
    {
        if (obj is OpeningHoursDay hours)
        {
            return hours.DayOfWeek == DayOfWeek
                && hours.OpeningTime == OpeningTime
                && hours.ClosingTime == ClosingTime;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return DayOfWeek.GetHashCode() ^ OpeningTime.GetHashCode() ^ ClosingTime.GetHashCode();
    }


    /// <summary>
    /// Checks if two opening hours overlap on the same day.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool Overlaps(OpeningHoursDay a, OpeningHoursDay b)
    {
        return a.DayOfWeek == b.DayOfWeek
            && a.OpeningTime <= b.ClosingTime
            && a.ClosingTime >= b.OpeningTime;
    }


    private void EnsureValidTimes()
    {
        if (OpeningTime >= ClosingTime)
        {
            throw new DomainValidationException($"{nameof(OpeningTime)} cannot be after {nameof(ClosingTime)}.");
        }
    }
}
