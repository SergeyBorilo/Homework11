using System.ComponentModel.DataAnnotations;
using Animals.Api.Constants;
using Animals.Api.Domain.Animals.Records;
using Animals.Application.Domain.Animals.Commands.CreateAnimal;
using Animals.Application.Domain.Animals.Commands.DeleteAnimal;
using Animals.Application.Domain.Animals.Commands.UpdateAnimal;
using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using Animals.Application.Domain.Animals.Queries.GetAnimals;
using Animals.Application.Domain.Animals.Queries.GetAnimalsByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Api.Domain.Animals;

[Route(Routes.Animals)]
public class AnimalsController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetAnimals(
        [FromQuery] [Required] int page = 1,
        [FromQuery] [Required] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAnimalsQuery(page, pageSize);
        var goods = await mediator.Send(query, cancellationToken);
        return Ok(goods);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAnimalDetails(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAnimalDetailsQuery(id);
        var good = await mediator.Send(query, cancellationToken);
        return Ok(good);
    }

    [HttpGet("get-by-name/{name}")]
    public async Task<ActionResult> GetAnimalByName(
        [FromRoute] string name,
        CancellationToken cancellationToken = default)
    {
        var query = new GetAnimalsByNameQuery(name);
        var animalsByName = await mediator.Send(query,cancellationToken);
        return Ok(animalsByName);
    }



    [HttpPost]
    public async Task<ActionResult> AddAnimal(
        [FromBody] [Required] CreateAnimalRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new CreateAnimalCommand(
            request.Name,
            request.Age,
            request.Description);
        var id = await mediator.Send(command, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAnimal(
        [FromRoute] Guid id,
        [FromBody] [Required] UpdateAnimalRequest request,
        CancellationToken cancellationToken = default)
    {
        var command = new UpdateAnimalCommand(
            id,
            request.Name,
            request.Age,
            request.Description);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAnimal(
        [FromRoute] Guid id,
        CancellationToken cancellationToken = default)
    {
        var command = new DeleteAnimalCommand(id);
        await mediator.Send(command, cancellationToken);
        return Ok();
    }
}
