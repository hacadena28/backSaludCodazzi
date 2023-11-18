using Api.Examples.EpsExamples;
using Api.Filters;
using Application.Common.Exceptions;
using Application.UseCases.Epses.Commands.EpsCreate;
using Application.UseCases.Epses.Commands.EpsDelete;
using Application.UseCases.Epses.Commands.EpsUpdate;
using Application.UseCases.Epses.Queries.GetEps;
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
    public async Task Create(EpsCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(EpsQuery), typeof(GetEpsQueryExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<List<EpsDto>> Get() => await _mediator.Send(new EpsQuery());

    [HttpPut("{id:guid}")]
    [SwaggerRequestExample(typeof(EpsCreateCommand), typeof(EpsCreateCommandExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task ChangeState(EpsChangeStateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException("The id of route no is the same of the command");
        }

        await _mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new EpsDeleteCommand(id));
}