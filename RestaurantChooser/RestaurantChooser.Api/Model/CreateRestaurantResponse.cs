namespace RestaurantChooser.Api.Model;

public class CreateRestaurantResponse
{
    public CreateRestaurantResponse(string restaurantId)
    {
        RestaurantId = restaurantId;
    }


    public string RestaurantId { get; set; }
}
