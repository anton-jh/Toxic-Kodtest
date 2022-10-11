using RestaurantChooser.Domain.Entities;

namespace RestaurantChooser.Business.Commands;
public interface IPickRandomRestaurantCommand
{
    Restaurant Execute();
}