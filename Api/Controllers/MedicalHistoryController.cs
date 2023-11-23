using Api.Examples.MedicalHistoryExamples;
using Api.Filters;
using Application.Common.Helpers.Pagination;
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
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(MedicalHistoryDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<MedicalHistoryDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationMedicalHistoryQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }
}