using RestaurantChooser.Data;
using RestaurantChooser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.DataAccess;
public class PickRandomRestaurantDataAccess : IPickRandomRestaurantDataAccess
{
    private readonly ApplicationDbContext _dbContext;


    public PickRandomRestaurantDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public IEnumerable<Restaurant> GetAll()
    {
        return _dbContext.Restaurants;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
