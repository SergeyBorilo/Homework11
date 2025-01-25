using Animals.Core.Domain.Models;

namespace Animals.Persistence.Core.Animals.DataProvider;

public interface IAnimalsDataProvider
{
    Task<AnimalDto?> GetById(Guid id);

    Task<AnimalDto?> GetByName(string name);

    Task<IEnumerable<AnimalDto>?> GetAll();

    Task Update(Animal animal);

    Task Add(Animal animal);

    Task Delete(Animal animal);
}