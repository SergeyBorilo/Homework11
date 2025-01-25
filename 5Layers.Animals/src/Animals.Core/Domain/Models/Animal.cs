using System.Runtime.CompilerServices;
using Animals.Core.Common;
using Animals.Core.Domain.Data;

// allow internal access for Animals.Infrastructure project
[assembly: InternalsVisibleTo("Animals.Infrastructure")]

namespace Animals.Core.Domain.Models;

public class Animal : IAggregateRoot
{
    // please leave it as is for Entity Framework. It needs it for materialization of entities.
    // read about it here: https://docs.microsoft.com/en-us/ef/core/modeling/constructors
    public Animal()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Description { get; private set; }

    internal Animal(
        Guid id, 
        string name,
        int age,
        string description)
    {
        Id = id;
        Name = name;
        Age = age;
        Description = description;
    }

    public void Update(UpdateAnimalData data)
    {
        Name = data.Name;
        Age = data.Age;
        Description = data.Description;
    }

    public static Animal Create(CreateAnimalData data)
    {
        return new Animal(
            Guid.NewGuid(),
            data.Name,
            data.Age,
            data.Description);
    }
}