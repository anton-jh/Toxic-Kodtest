using RestaurantChooser.Domain.Exceptions;
using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Domain.Entities;
/// <summary>
/// A restaurant.
/// </summary>
public class Restaurant : EntityBase<RestaurantId>
{
    private HashSet<Tag>? _tags;
    private HashSet<OpeningHoursDay>? _openingHours;


    /// <summary>
    /// Creates a new restaurant with a new unique id.
    /// </summary>
    /// <param name="name">The name of the restaurant.</param>
    public Restaurant(EntityName name, Address address)
    {
        Name = name;
        Address = address;
    }

    /// <summary>
    /// The name of the restaurant.
    /// </summary>
    public EntityName Name { get; private set; }

    /// <summary>
    /// The address of the restaurant.
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    /// Opening hours per day of the week.
    /// </summary>
    public IEnumerable<OpeningHoursDay> OpeningHours => LazyLoad(ref _openingHours);

    /// <summary>
    /// All tags assigned to this restaurant.
    /// </summary>
    public IEnumerable<Tag> Tags => LazyLoad(ref _tags);


    public void UpdateName(EntityName name)
    {
        Name = name;
    }


    /// <summary>
    /// Associates an existing tag with this restaurant.
    /// </summary>
    /// <param name="tag"></param>
    public void AddTag(Tag tag)
    {
        Actual(Tags).Add(tag);
    }

    /// <summary>
    /// Removes the association between the tag and this restaurant.
    /// </summary>
    /// <param name="tagId"></param>
    public void RemoveTag(TagId tagId)
    {
        Actual(Tags).RemoveWhere(tag => tag.Id == tagId);
    }


    /// <summary>
    /// Adds opening hours for a day of the week.
    /// </summary>
    /// <param name="hours"></param>
    public void AddOpeningHours(OpeningHoursDay hours)
    {
        foreach (OpeningHoursDay otherHours in Actual(OpeningHours))
        {
            if (OpeningHoursDay.Overlaps(hours, otherHours))
            {
                throw new DomainValidationException("The hours overlap with the existing hours for this day.");
            }
        }
    }


    /// <summary>
    /// Removes opening hours for a day of the week.
    /// </summary>
    /// <param name="hours"></param>
    public void RemoveOpeningPeriod(OpeningHoursDay hours)
    {
        Actual(OpeningHours).Remove(hours);
    }
}
