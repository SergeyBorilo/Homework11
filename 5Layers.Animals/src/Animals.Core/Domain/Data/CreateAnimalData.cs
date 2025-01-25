namespace Animals.Core.Domain.Data;

public record CreateAnimalData(
    string Name,
    int Age,
    string Description);