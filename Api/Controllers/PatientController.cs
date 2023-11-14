using Api.Filters;
using Application.UseCases.Patient.Commands.PatientUpdate;
using Application.UseCases.Patient.Queries.GetPatient;

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

    [HttpPut]
    public async Task<PatientDto> Update(PatientUpdateCommand command)
    {
        var updatedPatient = await _mediator.Send(command);
        return updatedPatient;
    }
}