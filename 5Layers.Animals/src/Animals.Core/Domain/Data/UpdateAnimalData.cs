namespace Animals.Core.Domain.Data;

public record UpdateAnimalData(
    string Name,
    int Age,
    string Description);