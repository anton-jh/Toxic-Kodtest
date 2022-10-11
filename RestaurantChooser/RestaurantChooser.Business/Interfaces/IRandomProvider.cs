using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.Interfaces;
public interface IRandomProvider
{
    int GetRandom(int exclMax);
}
