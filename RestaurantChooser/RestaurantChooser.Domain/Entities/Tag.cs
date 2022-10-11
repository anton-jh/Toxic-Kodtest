using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.Validation;
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
public class Tag : LazyLoadingEntityBase
{
    private HashSet<Restaurant>? _restaurants;


    /// <summary>
    /// Creates a new tag with a unique id.
    /// </summary>
    /// <param name="name">The name of the tag.</param>
    public Tag(string name)
    {
        name.MustBe().NotEmptyOrWhitespace();

        Name = name;
    }


    /// <summary>
    /// The name of this tag.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// All the restaurants that are tagged with this tag.
    /// </summary>
    public IEnumerable<Restaurant> Restaurants => LazyLoad(ref _restaurants);
}
