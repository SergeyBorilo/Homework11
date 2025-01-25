namespace Animals.Application.Domain.Animals.Queries.GetAnimals;

public record AnimalDto(
    Guid Id,
    string Name,
    int Age);
