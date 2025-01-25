using Animals.Application.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Queries.GetAnimals;

public record GetAnimalsQuery(int Page, int PageSize) : IRequest<PageResponse<AnimalDto[]>>;