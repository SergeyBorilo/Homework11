using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals.Application.Common;
using Animals.Application.Domain.Animals.Queries.GetAnimals;
using Animals.Core.Domain.Common;
using Animals.Core.Domain.Models;
using Animals.Persistence.Core.Animals.DataProvider;
using MediatR;
using AnimalDto = Animals.Application.Domain.Animals.Queries.GetAnimals.AnimalDto;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimals;

internal class GetAnimalsQueryHandler(IAnimalsDataProvider animalsDataProvider)
    : IRequestHandler<GetAnimalsQuery, PageResponse<AnimalDto[]>>
{
    public async Task<PageResponse<AnimalDto[]>> Handle(
        GetAnimalsQuery query,
        CancellationToken cancellationToken)
    {
        var skip = query.PageSize * (query.Page - 1);

        var animals = await animalsDataProvider.GetAll();

        var count = animals.Count();

        var result = animals
            .Skip(skip)
            .Take(query.PageSize)
            .Select(a => new AnimalDto(
                a.Id,
                a.Name,
                a.Age))
            .ToArray();

        return new PageResponse<AnimalDto[]>(count, result);
    }
}
