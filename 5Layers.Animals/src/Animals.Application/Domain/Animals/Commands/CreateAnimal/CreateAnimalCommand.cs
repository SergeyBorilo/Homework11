using MediatR;

namespace Animals.Application.Domain.Animals.Commands.CreateAnimal;

public record CreateAnimalCommand(
    string Name,
    int Age,
    string Description) : IRequest<Guid>;