using Api.Examples.PatientExamples;
using Api.Filters;
using Application.UseCases.Patient.Commands.PatientCreate;
using Application.UseCases.Patient.Commands.PatientDelete;
using Application.UseCases.Patient.Commands.PatientUpdate;
using Application.UseCases.Patient.Queries.GetPatient;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    // [SwaggerRequestExample(typeof(PatientCreateCommand), typeof(PatientCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PatientCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    public async Task<PatientDtoEmpty> Create(PatientCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(PatientQuery), typeof(GetPatientQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PatientCreateResponseExample))]
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

    [HttpDelete("{id}")]
    public async Task<PatientDtoEmpty> Delete(Guid id)
    {
        var deletePatient = await _mediator.Send(new PatientDeleteCommand(id));
        return deletePatient;
    }
    
    
}