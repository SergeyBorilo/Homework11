using Animals.Core.Domain.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.DeleteAnimal;

public class DeleteAnimalCommandHandler(IAnimalsRepository animalsRepository) : IRequestHandler<DeleteAnimalCommand>
{
    public async Task Handle(
        DeleteAnimalCommand command,
        CancellationToken cancellationToken)
    {
        var animal = await animalsRepository.GetById(command.Id);
        await animalsRepository.Delete(animal);
    }
}