using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Domain.Entities;

/// <summary>
/// A tag for taggin a restaurant with what type of food they sell and so on.
/// </summary>
public class Tag : EntityBase<TagId>
{
    private HashSet<Restaurant>? _restaurants;


    /// <summary>
    /// Creates a new tag with a unique id.
    /// </summary>
    /// <param name="name">The name of the tag.</param>
    public Tag(EntityName name)
    {
        Name = name;

        _id = TagId.From(Guid.NewGuid());
    }


    /// <summary>
    /// The name of this tag.
    /// </summary>
    public EntityName Name { get; private set; }

    /// <summary>
    /// All the restaurants that are tagged with this tag.
    /// </summary>
    public IEnumerable<Restaurant> Restaurants => LazyLoad(ref _restaurants);
}
