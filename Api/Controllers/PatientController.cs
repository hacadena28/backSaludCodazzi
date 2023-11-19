using Api.Filters;
using Application.Common.Exceptions;
using Application.UseCases.Patients.Commands.PatientUpdate;
using Application.UseCases.Patients.Queries.GetPatient;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator) => _mediator = mediator;


    [HttpGet]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    public async Task<List<PatientDto>> Get() => await _mediator.Send(new PatientQuery());

    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task Update(PatientUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException("The id of route no is the same of the command");
        }

        await _mediator.Send(command);
    }
}