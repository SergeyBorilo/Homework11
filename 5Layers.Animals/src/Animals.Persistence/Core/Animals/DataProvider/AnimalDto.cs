namespace Animals.Persistence.Core.Animals.DataProvider;

public record AnimalDto(
    Guid Id,
    string Name,
    int Age,
    string Description);