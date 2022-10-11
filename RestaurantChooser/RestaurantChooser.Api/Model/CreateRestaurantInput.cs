using System.Text.Json.Serialization;

namespace RestaurantChooser.Api.Model;

public class CreateRestaurantInput
{
    [JsonConstructor]
    public CreateRestaurantInput(string name, string address, IEnumerable<string> tags, IEnumerable<OpeningHoursInput> openingHours)
    {
        Name = name;
        Address = address;
        Tags = tags;
        OpeningHours = openingHours;
    }


    public string Name { get; set; }
    public string Address { get; set; }
    public IEnumerable<string> Tags { get; set; }
    public IEnumerable<OpeningHoursInput> OpeningHours { get; set; }
}
