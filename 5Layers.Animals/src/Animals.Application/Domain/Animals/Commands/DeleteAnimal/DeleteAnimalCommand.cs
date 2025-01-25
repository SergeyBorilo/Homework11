using MediatR;

namespace Animals.Application.Domain.Animals.Commands.DeleteAnimal;

public record DeleteAnimalCommand(Guid Id) : IRequest;