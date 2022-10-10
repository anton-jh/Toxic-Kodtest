using Microsoft.EntityFrameworkCore;
using RestaurantChooser.Api.DbConfig;
using RestaurantChooser.Api.EndpointDefinitions;
using RestaurantChooser.Api.Extensions;
using RestaurantChooser.Data;

var builder = WebApplication.CreateBuilder(args);
IDbConfig dbConfig = new DefaultDbConfig();

builder.Services.AddSqlite<ApplicationDbContext>(dbConfig.ConnectionString);

builder.Services.FromEndpointDefinitions<RestaurantEndpointDefinitions>();


var app = builder.Build();

InitDatabase();

app.FromEndpointDefinitions<RestaurantEndpointDefinitions>();


app.Run();



void InitDatabase()
{
    dbConfig.Prepare();

    using (IServiceScope tempScope = app.Services.CreateScope())
    {
        using var dbContext = tempScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}
