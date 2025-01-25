using Animals.Core.Domain.Models;

namespace Animals.Core.Domain.Common;

public interface IAnimalsRepository
{
    Task<Animal> GetById(Guid id);

    Task<Animal> GetByName(string name);

    // this method usually is not needed as EF Core tracks changes to entities. Will learn later.
    Task Update(Animal animal);

    // for the love of whatever higher power you believe in, please don't use Task here.
    // Read the documentation of the EF Core for further reasoning 
    Task Add(Animal animal);

    // for the love of whatever higher power you believe in, please don't use Task here.
    // Read the documentation of the EF Core for further reasoning
    Task Delete(Animal animal);
}