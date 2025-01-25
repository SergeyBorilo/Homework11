namespace Animals.Application.Domain.Animals.Queries.GetAnimalDetails;

public record AnimalDetailsDto(
    Guid Id,
    string Name,
    int Age,
    string Description);