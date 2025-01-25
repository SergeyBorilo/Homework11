using MediatR;

namespace Animals.Application.Domain.Animals.Queries.GetAnimalDetails;

public record GetAnimalDetailsQuery(Guid Id) : IRequest<AnimalDetailsDto>;