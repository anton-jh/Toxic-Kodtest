# Pre-interview assignment


## System description
We love lunch, but it's not easy to find the right restaurant each day. A simple tool would be nice to help us select which restaurant to visit. It should be able to add new restaurants with information such as what food they serve (chinese, swedish, pizza etc.), where the restaurant is located, and it's opening hours. A randomising function can be used to select "the restaurant of the day", but make sure we don't get the same one too often!


## Instructions
* Fork or clone this repository (click "Use this Template")
* Make an estimate on how long you think it would take to complete this project
* Use .NET 6 for your system
* Include instructions on how to run your project in this README
* Spend approximately 4-6 hours on this project

When you're done, ideally within a week of you seeing this, send us a pull request with your work in it to this repository! Bonus points if your commits are descriptive. =)


## Running this

The project is a normal Aspnetcore WebApplication and can be run through Visual Studio or the dotnet cli.


## Endpoints

### POST `/restaurants/`

Create a new restaurant.

#### Model

```json
{
    "name": "string",
    "address": "string",
    "tags": [
        "string"
    ],
    "openingHours": [
        {
            "dayOfWeek": "string (Capitalized, Monday-Sunday)",
            "openingTime": "hh:mm",
            "closingTime": "hh:mm"
        }
    ]
}
```

### GET `/restaurants`

Gets all restaurants.

#### Model

```json
[
    {
        "id": "string, (guid/uuid)",
        "name": "string",
        "address": "string",
        "tags": [
            "string"
        ],
        "openingHours": [
            {
                "dayOfWeek": "string (Capitalized, Monday-Sunday)",
                "openingTime": "hh:mm",
                "closingTime": "hh:mm"
            }
        ]
    }
]
```

### GET `/restaurants/{id}`

Gets the restaurant with the provided id.

#### Params
- `id`: Route parameter, guid/uuid

#### Model

```json
{
    "id": "string, (guid/uuid)",
    "name": "string",
    "address": "string",
    "tags": [
        "string"
    ],
    "openingHours": [
        {
            "dayOfWeek": "string (Capitalized, Monday-Sunday)",
            "openingTime": "hh:mm",
            "closingTime": "hh:mm"
        }
    ]
}
```

### GET `/restaurant-of-the-day`

Gets a randomly selected restaurant. Selection is ensured to not be repetitive.

#### Model

```json
{
    "id": "string, (guid/uuid)",
    "name": "string",
    "address": "string",
    "tags": [
        "string"
    ],
    "openingHours": [
        {
            "dayOfWeek": "string (Capitalized, Monday-Sunday)",
            "openingTime": "hh:mm",
            "closingTime": "hh:mm"
        }
    ]
}
```
