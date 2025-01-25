using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using Animals.Core.Domain.Common;
using Animals.Persistence.Core.Animals.DataProvider;
using MediatR;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimalDetails;

public class GetAnimalDetailsQueryHandler(IAnimalsRepository dataProvider) : IRequestHandler<GetAnimalDetailsQuery, AnimalDetailsDto>
{
    public async Task<AnimalDetailsDto> Handle(
        GetAnimalDetailsQuery query, 
        CancellationToken cancellationToken)
    {
        var animal = await dataProvider.GetById(query.Id);

        return new AnimalDetailsDto(
            animal.Id,
            animal.Name,
            animal.Age,
            animal.Description);
    }
}