using Api.Filters;
using Application.Common.Exceptions;
using Application.UseCases.Medics.Commands.DoctorUpdate;
using Application.UseCases.Medics.Queries.GetDoctor;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator) => _mediator = mediator;


    [HttpGet]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
    public async Task<List<DoctorDto>> Get() => await _mediator.Send(new DoctorQuery());

    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task Update(DoctorUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException("The id of route no is the same of the command");
        }

        await _mediator.Send(command);
    }
}