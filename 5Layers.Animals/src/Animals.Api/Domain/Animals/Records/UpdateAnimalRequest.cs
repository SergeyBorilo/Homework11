namespace Animals.Api.Domain.Animals.Records;

public record UpdateAnimalRequest(
    string Name,
    int Age,
    string Description);