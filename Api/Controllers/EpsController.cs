using Api.Examples.EpsExamples;
using Api.Filters;
using Application;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Epses.Commands.EpsCreate;
using Application.UseCases.Epses.Commands.EpsDelete;
using Application.UseCases.Epses.Commands.EpsUpdate;
using Application.UseCases.Epses.Queries.GetEps;
using Application.UseCases.Epses.Queries.GetEpsByID;
using Application.UseCases.Epses.Queries.GetEpsByName;
using Application.UseCases.Users.Queries.GetPaginationUser;

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
    [SwaggerRequestExample(typeof(PaginationEpsQuery), typeof(GetEpsQueryExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<EpsDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationEpsQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task<EpsDto> GetById(Guid id)
    {
        return await _mediator.Send(new EpsByIdQuery(id));
    }

    [HttpGet("name/{name}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<EpsDto> GetByName(string name)
    {
        return await _mediator.Send(new EpsByNameQuery(name));
    }


    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task ChangeState(EpsUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException(Messages.IdDoNotMatch);
        }

        await _mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(EpsDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new EpsDeleteCommand(id));
}