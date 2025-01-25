namespace Animals.Api.Domain.Animals.Records;

public record CreateAnimalRequest(
    string Name,
    int Age,
    string Description);