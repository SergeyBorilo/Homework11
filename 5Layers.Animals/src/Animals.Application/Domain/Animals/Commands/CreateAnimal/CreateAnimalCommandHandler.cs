using Animals.Core.Domain.Common;
using Animals.Core.Domain.Data;
using Animals.Core.Domain.Models;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.CreateAnimal;

internal class CreateAnimalCommandHandler(IAnimalsRepository animalsRepository) : IRequestHandler<CreateAnimalCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateAnimalCommand command, 
        CancellationToken cancellationToken)
    {
        var data = new CreateAnimalData(command.Name, command.Age, command.Description);

        var animal = Animal.Create(data);

        animalsRepository.Add(animal);

        return animal.Id;
    }
}