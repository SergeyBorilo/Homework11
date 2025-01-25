using System.Diagnostics;
using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using Animals.Application.Domain.Animals.Queries.GetAnimalsByName;
using Animals.Persistence.Core.Animals.DataProvider;
using MediatR;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimalsByName;

internal class GetAnimalsByNameQueryHandler(IAnimalsDataProvider animalsDataProvider)
    : IRequestHandler<GetAnimalsByNameQuery, List<AnimalsByNameDto>>
{
    public async Task<List<AnimalsByNameDto>> Handle(GetAnimalsByNameQuery query, CancellationToken cancellationToken)
    {
        var animals = await animalsDataProvider.GetAll();

        Debug.Assert(animals != null, nameof(animals) + " != null");
        var result = animals
            .Where(animal => animal.Name.Contains(query.Name))
            .OrderBy(animal => animal.Name)
            .Select(animal => new AnimalsByNameDto()
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Description = animal.Description,
            })
            .ToList();

        return result;

    }
}
