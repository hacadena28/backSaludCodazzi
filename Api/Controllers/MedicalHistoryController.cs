using Api.Examples.MedicalHistoryExamples;
using Api.Filters;
using Application.UseCases.MedicalHistorys.Commands.MedicalHistoryCreate;
using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicalHistory
{
    private readonly IMediator _mediator;

    public MedicalHistory(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [SwaggerRequestExample(typeof(MedicalHistoryCreateCommand), typeof(MedicalHistoryCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(MedicalHistoryCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(MedicalHistoryDto), StatusCodes.Status200OK)]
    public async Task Create(MedicalHistoryCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(MedicalHistoryQuery), typeof(GetMedicalHistoryQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(MedicalHistoryCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(MedicalHistoryDto), StatusCodes.Status200OK)]
    public async Task<List<MedicalHistoryDto>> Get() => await _mediator.Send(new MedicalHistoryQuery());
}