using RestaurantChooser.Api.Model;
using RestaurantChooser.Api.Validators;
using RestaurantChooser.Business.Commands;
using RestaurantChooser.Data;
using RestaurantChooser.Domain.Entities;
using RestaurantChooser.Domain.Ids;
using RestaurantChooser.Domain.ValueObjects;

namespace RestaurantChooser.Api.Services;

public class RestaurantService : IRestaurantService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICreateRestaurantCommand _createRestaurantCommand;
    private readonly ICreateRestaurantInputValidator _createRestaurantValidator;


    public RestaurantService(
        ApplicationDbContext dbContext,
        ICreateRestaurantCommand createRestaurantCommand,
        ICreateRestaurantInputValidator createRestaurantValidator)
    {
        _dbContext = dbContext;
        _createRestaurantCommand = createRestaurantCommand;
        _createRestaurantValidator = createRestaurantValidator;
    }


    public IEnumerable<RestaurantResponse> GetAll()
    {
        return from Restaurant restaurant in _dbContext.Restaurants
               select new RestaurantResponse(restaurant);
    }

    public CreateRestaurantResponse Create(CreateRestaurantInput input)
    {
        _createRestaurantValidator.EnsureValid(input);

        RestaurantId id = _createRestaurantCommand.Execute(
            EntityName.From(input.Name),
            Address.From(input.Address),
            input.Tags.Select(name => new Tag(name)),
            input.OpeningHours.Select(openingHours => new OpeningHoursDay(
                Enum.Parse<DayOfWeek>(openingHours.DayOfWeek),
                TimeOnly.Parse(openingHours.OpeningTime),
                TimeOnly.Parse(openingHours.ClosingTime))));

        return new(id.Value.ToString());
    }
}
