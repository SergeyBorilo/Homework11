using Animals.Core.Domain.Common;
using Animals.Core.Domain.Data;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.UpdateAnimal;

internal class UpdateAnimalCommandHandler(IAnimalsRepository animalsRepository) : IRequestHandler<UpdateAnimalCommand>
{
    public async Task Handle(
        UpdateAnimalCommand command,
        CancellationToken cancellationToken)
    {
        var animal = await animalsRepository.GetById(command.Id);
        var data = new UpdateAnimalData(command.Name, command.Age, command.Description);
        animal.Update(data);
        animalsRepository.Update(animal);
    }
}