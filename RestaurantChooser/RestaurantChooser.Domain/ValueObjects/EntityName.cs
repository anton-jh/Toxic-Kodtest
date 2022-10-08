using RestaurantChooser.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RestaurantChooser.Domain.ValueObjects;
public class EntityName : ValueOf<string, EntityName>
{
    protected override void Validate()
    {
        Value.MustBe().NotEmptyOrWhitespace();
    }
}
