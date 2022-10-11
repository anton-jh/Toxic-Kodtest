using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantChooser.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChooser.Data.EntityTypeConfigurations;
internal class RestaurantEntityTypeConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsMany(x => x.OpeningHours, y =>
            y.HasKey("Id"));

        builder
            .HasMany(x => x.Tags)
            .WithMany(x => x.Restaurants);
    }
}
