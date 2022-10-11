using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Business.Exceptions;
public class NameTakenException : Exception
{
    public NameTakenException(EntityName name)
        : base($"Entity name '{name}' is taken.")
    {
    }
}
