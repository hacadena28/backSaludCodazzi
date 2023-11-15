using Api.Examples.EpsExamples;
using Api.Filters;
using Application.UseCases.Eps.Commands.EpsCreate;
using Application.UseCases.Eps.Commands.EpsDelete;
using Application.UseCases.Eps.Commands.EpsUpdate;
using Application.UseCases.Eps.Queries.GetEps;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EpsController
{
    private readonly IMediator _mediator;

    public EpsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [SwaggerRequestExample(typeof(EpsCreateCommand), typeof(EpsCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(EpsCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<EmptyEpsDto> Create(EpsCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(EpsQuery), typeof(GetEpsQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(EpsCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<List<EpsDto>> Get() => await _mediator.Send(new EpsQuery());

    [HttpPut]
    public async Task<EpsDto> Update(EpsUpdateCommand command)
    {
        var updatedEps = await _mediator.Send(command);
        return updatedEps;
    }

    [HttpDelete("{id}")]
    public async Task<EmptyEpsDto> Delete(Guid id)
    {
        var deleteEps = await _mediator.Send(new EpsDeleteCommand(id));
        return deleteEps;
    }
}