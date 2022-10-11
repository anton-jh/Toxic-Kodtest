using RestaurantChooser.Business.DataAccess;
using RestaurantChooser.Business.Exceptions;
using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.Commands;
public class CreateRestaurantCommand : ICreateRestaurantCommand
{
    private readonly ICreateRestaurantDataAccess _dataAccess;


    public CreateRestaurantCommand(ICreateRestaurantDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }


    public RestaurantId Execute(EntityName name, Address address, IEnumerable<Tag> tags, IEnumerable<OpeningHoursDay> openingHours)
    {
        EnsureNameIsNotTaken(name);

        IEnumerable<Tag> mergedTags = MergeTagsWithExisting(tags);

        Restaurant restaurant = new(name, address, openingHours, mergedTags);

        _dataAccess.AddAndSaveChanges(restaurant);

        return restaurant.Id;
    }


    private void EnsureNameIsNotTaken(EntityName name)
    {
        if (_dataAccess.IsNameTaken(name))
        {
            throw new NameTakenException(name);
        }
    }

    private IEnumerable<Tag> MergeTagsWithExisting(IEnumerable<Tag> tags)
    {
        IEnumerable<Tag> existingTags = _dataAccess.GetTags();

        foreach (Tag newTag in tags)
        {
            if (existingTags.FirstOrDefault(x => x.Name == newTag.Name) is Tag existingTag)
            {
                yield return existingTag;
            }
            else
            {
                yield return newTag;
            }
        }
    }
}
