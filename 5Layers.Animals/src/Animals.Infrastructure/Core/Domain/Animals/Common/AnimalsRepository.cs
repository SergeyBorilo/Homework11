using Animals.Core.Domain.Common;
using Animals.Core.Domain.Models;
using Animals.Persistence.Core.Animals.DataProvider;

namespace Animals.Infrastructure.Core.Domain.Animals.Common;

public class AnimalsRepository(IAnimalsDataProvider animalsDataProvider) : IAnimalsRepository
{
    public async Task<Animal> GetById(Guid id)
    {
        var animal = await animalsDataProvider.GetById(id) ?? throw new InvalidOperationException("Animal was not found");
        return new Animal(
            animal.Id,
            animal.Name, 
            animal.Age, 
            animal.Description);
    }

    public Task<Animal> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Animal animal)
    {
        await animalsDataProvider.Update(animal);
    }

    public async Task Add(Animal animal)
    {
        await animalsDataProvider.Add(animal);
    }

    public async Task Delete(Animal animal)
    {
        await animalsDataProvider.Delete(animal);
    }
}