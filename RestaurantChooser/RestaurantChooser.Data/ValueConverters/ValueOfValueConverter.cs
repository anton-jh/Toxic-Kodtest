using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RestaurantChooser.Data.ValueConverters;
internal class ValueOfValueConverter<TValueOf, TValue> : ValueConverter<TValueOf, TValue> where TValueOf : ValueOf<TValue, TValueOf>, new()
{
    public ValueOfValueConverter()
        : base(v => v.Value, v => ValueOf<TValue, TValueOf>.From(v))
    {
    }
}
