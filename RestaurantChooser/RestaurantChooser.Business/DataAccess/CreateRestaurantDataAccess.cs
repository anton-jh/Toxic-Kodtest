using RestaurantChooser.Data;
using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.DataAccess;
public class CreateRestaurantDataAccess : ICreateRestaurantDataAccess
{
    private readonly ApplicationDbContext _dbContext;


    public CreateRestaurantDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void AddAndSaveChanges(Restaurant restaurant)
    {
        _dbContext.Restaurants.Add(restaurant);

        _dbContext.SaveChanges();
    }

    public bool IsNameTaken(EntityName name)
    {
        return _dbContext.Restaurants.Any(x => x.Name == name);
    }

    public IEnumerable<Tag> GetTags()
    {
        return _dbContext.Tags;
    }

    public IEnumerable<Restaurant> GetAll()
    {
        return _dbContext.Restaurants;
    }
}
