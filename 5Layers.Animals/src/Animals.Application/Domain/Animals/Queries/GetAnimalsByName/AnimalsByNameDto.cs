namespace Animals.Application.Domain.Animals.Queries.GetAnimalsByName;

public record AnimalsByNameDto
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public int Age { get; init; }
    public string? Description { get; init; }
}
