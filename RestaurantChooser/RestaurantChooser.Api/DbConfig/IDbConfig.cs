namespace RestaurantChooser.Api.DbConfig;

public interface IDbConfig
{
    string ConnectionString { get; }

    void Prepare();
}