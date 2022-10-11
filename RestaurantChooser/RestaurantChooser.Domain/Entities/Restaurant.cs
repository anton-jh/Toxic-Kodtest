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
public class Restaurant : LazyLoadingEntityBase
{
    private RestaurantId? _id;
    private HashSet<OpeningHoursDay>? _openingHours;
    private HashSet<Tag>? _tags;


    /// <summary>
    /// Creates a new restaurant with a new unique id.
    /// </summary>
    /// <param name="name">The name of the restaurant.</param>
    public Restaurant(EntityName name, Address address, IEnumerable<OpeningHoursDay> openingHours, IEnumerable<Tag> tags)
    {
        _id = RestaurantId.From(Guid.NewGuid());
        Name = name;
        Address = address;

        EnsureValidOpeningHours(Array.Empty<OpeningHoursDay>(), openingHours);
        _openingHours = new(openingHours);

        _tags = new(tags);
    }

    /// <summary>
    /// Private constructor for EF Core
    /// </summary>
    private Restaurant(EntityName name, Address address)
    {
        Name = name;
        Address = address;
    }


    /// <summary>
    /// The unique id of the restaurant.
    /// </summary>
    public RestaurantId Id => _id ?? throw new EntityNotAttachedException();


    /// <summary>
    /// The number of times this restaurant has been randomly picked.
    /// </summary>
    public PickFrequency PickFrequency { get; private set; } = PickFrequency.From(0);

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
    /// Increment pick frequency by one.
    /// </summary>
    public void IncrementPickFrequency()
    {
        PickFrequency = PickFrequency.Increment();
    }

    /// <summary>
    /// Reset pick frequency.
    /// </summary>
    public void ResetPickFrequency()
    {
        PickFrequency = PickFrequency.From(0);
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
    public void RemoveTag(Tag tag)
    {
        Actual(Tags).Remove(tag);
    }


    /// <summary>
    /// Adds opening hours for a day of the week.
    /// </summary>
    /// <param name="hours"></param>
    public void AddOpeningHours(OpeningHoursDay hours)
    {
        EnsureValidOpeningHours(Actual(OpeningHours), new [] {hours});

        Actual(OpeningHours).Add(hours);
    }


    /// <summary>
    /// Removes opening hours for a day of the week.
    /// </summary>
    /// <param name="hours"></param>
    public void RemoveOpeningPeriod(OpeningHoursDay hours)
    {
        Actual(OpeningHours).Remove(hours);
    }


    public static void EnsureValidOpeningHours(IEnumerable<OpeningHoursDay> existingHours, IEnumerable<OpeningHoursDay> newHours)
    {
        foreach (OpeningHoursDay periodToAdd in newHours)
        {
            foreach (OpeningHoursDay existingPeriod in existingHours)
            {
                if (OpeningHoursDay.Overlaps(periodToAdd, existingPeriod))
                {
                    throw new DomainValidationException("The hours overlap with the existing hours for this day.");
                }
            }
        }
    }
}
