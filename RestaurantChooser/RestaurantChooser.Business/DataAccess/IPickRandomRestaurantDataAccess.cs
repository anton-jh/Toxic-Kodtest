using RestaurantChooser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.DataAccess;
public interface IPickRandomRestaurantDataAccess
{
    IEnumerable<Restaurant> GetAll();
    void Save();
}
