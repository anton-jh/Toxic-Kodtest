using RestaurantChooser.Business.Interfaces;

namespace RestaurantChooser.Api.Services;

public class DefaultRandomProvider : IRandomProvider
{
    private readonly Random _random;


    public DefaultRandomProvider()
    {
        _random = new();
    }


    public int GetRandom(int exclMax)
    {
        return _random.Next(exclMax);
    }
}
