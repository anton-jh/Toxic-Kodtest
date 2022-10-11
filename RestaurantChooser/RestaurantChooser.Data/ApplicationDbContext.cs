using Microsoft.EntityFrameworkCore;
using RestaurantChooser.Data.ValueConverters;
using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace RestaurantChooser.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        #region ValueConverters
        void AddValueOfConverter<TValueOf, TValue>()
            where TValueOf : ValueOf<TValue, TValueOf>, new()
        {
            configurationBuilder
                .Properties<TValueOf>()
                .HaveConversion<ValueOfValueConverter<TValueOf, TValue>>();
        }

        AddValueOfConverter<RestaurantId, Guid>();
        AddValueOfConverter<TagId, Guid>();
        AddValueOfConverter<Address, string>();
        AddValueOfConverter<EntityName, string>();
        #endregion
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }


    public DbSet<Restaurant> Restaurants { get; private set; } = null!;
    public DbSet<Tag> Tags { get; private set; } = null!;
}
