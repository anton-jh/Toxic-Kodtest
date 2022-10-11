using RestaurantChooser.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RestaurantChooser.Domain.ValueObjects;
public class PickFrequency : ValueOf<int, PickFrequency>
{
    protected override void Validate()
    {
        Value.MustBe().GreaterThanOrEqualTo(0);
    }

    public PickFrequency Increment()
    {
        return From(Value + 1);
    }
}
