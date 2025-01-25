using System.Text.Json;
using Animals.Core.Domain.Models;

namespace Animals.Persistence.Core.Animals.DataProvider;

public class AnimalsDataProvider : IAnimalsDataProvider
{
    private string _filePath = "animals.json";
    // add crud methods to work with animals in the file system

    public async Task<AnimalDto?> GetById(Guid id)
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;
        var animals = JsonSerializer.Deserialize<List<AnimalDto>>(data);
        return animals?.FirstOrDefault(a => a.Id == id);
    }

    public async Task<AnimalDto?> GetByName(string name)
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;
        var animals = JsonSerializer.Deserialize<List<AnimalDto>>(data);
        return animals?.FirstOrDefault(a => a.Name == name);
    }

    public async Task<IEnumerable<AnimalDto>?> GetAll()
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;
        var animals = JsonSerializer.Deserialize<AnimalDto[]>(data);
        return animals;
    }

    public async Task Update(Animal animal)
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;
        var animals = JsonSerializer.Deserialize<List<AnimalDto>>(data);
        var animalToUpdate = animals?.FirstOrDefault(a => a.Id == animal.Id)
                             ?? throw new InvalidOperationException("Animal was not found");
        var index = animals.IndexOf(animalToUpdate);
        animals[index] = new AnimalDto(
            animal.Id,
            animal.Name,
            animal.Age,
            animal.Description);

        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(animals));
    }

    public async Task Add(Animal animal)
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;

        var animals = JsonSerializer.Deserialize<AnimalDto[]>(data).ToList();

        animals.Add(
            new AnimalDto(
            animal.Id,
            animal.Name,
            animal.Age,
            animal.Description));

        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(animals));
    }

    public async Task Delete(Animal animal)
    {
        var data = await File.ReadAllTextAsync(_filePath);
        data = string.IsNullOrEmpty(data) ? "[]" : data;
        var animals = JsonSerializer.Deserialize<AnimalDto[]>(data).ToList();
        var animalToDelete = animals?.FirstOrDefault(a => a.Id == animal.Id)
                             ?? throw new InvalidOperationException("Animal was not found");
        animals.Remove(animalToDelete);
        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(animals));
    }
}
