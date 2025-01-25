using MediatR;

namespace Animals.Application.Domain.Animals.Commands.UpdateAnimal;

public record UpdateAnimalCommand(
    Guid Id,
    string Name,
    int Age,
    string Description) : IRequest;