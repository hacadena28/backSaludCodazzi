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
    public async Task Create(EpsCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(EpsQuery), typeof(GetEpsQueryExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<List<EpsDto>> Get() => await _mediator.Send(new EpsQuery());

    [HttpPut]
    [SwaggerRequestExample(typeof(EpsCreateCommand), typeof(EpsCreateCommandExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task ChangeState(EpsChangeStateCommand command) => await _mediator.Send(command);

    [HttpDelete("{id}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new EpsDeleteCommand(id));
}