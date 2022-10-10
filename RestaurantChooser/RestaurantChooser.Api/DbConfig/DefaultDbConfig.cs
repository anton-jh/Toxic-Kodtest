namespace RestaurantChooser.Api.DbConfig;

public class DefaultDbConfig : IDbConfig
{
    private static readonly string _dbFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AntonJH", "RestaurantChooser");
    private static readonly string _dbPath = Path.Join(_dbFolder, "RestaurantChooser.db");


    public string ConnectionString => $"Data Source={_dbPath}";


    public void Prepare()
    {
        Directory.CreateDirectory(_dbFolder);
    }
}
