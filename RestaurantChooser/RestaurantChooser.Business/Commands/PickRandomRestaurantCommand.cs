using RestaurantChooser.Business.DataAccess;
using RestaurantChooser.Business.Interfaces;
using RestaurantChooser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.Commands;
public class PickRandomRestaurantCommand : IPickRandomRestaurantCommand
{
    private readonly IPickRandomRestaurantDataAccess _dataAccess;
    private readonly IRandomProvider _randomProvider;


    public PickRandomRestaurantCommand(IPickRandomRestaurantDataAccess dataAccess, IRandomProvider randomProvider)
    {
        _dataAccess = dataAccess;
        _randomProvider = randomProvider;
    }


    public Restaurant Execute()
    {
        IEnumerable<Restaurant> allRestaurants = _dataAccess.GetAll();

        double averagePickFrequency = allRestaurants.Average(x => x.PickFrequency.Value);

        List<Restaurant> belowAverageRestaurants = allRestaurants.Where(x => x.PickFrequency.Value <= averagePickFrequency).ToList();

        int selectedIndex = _randomProvider.GetRandom(belowAverageRestaurants.Count);
        Restaurant pick = belowAverageRestaurants[selectedIndex];

        pick.IncrementPickFrequency();
        _dataAccess.Save();

        return pick;
    }
}
