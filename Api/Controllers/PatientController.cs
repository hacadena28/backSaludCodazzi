using Api.Filters;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Patients.Commands.PatientUpdate;
using Application.UseCases.Patients.Queries.GetPatient;
using Application.UseCases.Patients.Queries.GetPatientByDocumentNumber;
using Application.UseCases.Patients.Queries.GetPatientByID;
using Application.UseCases.Users.Queries.GetPaginationUser;

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
    public async Task<ResponsePagination<PatientDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationPatientQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
    public async Task<PatientDto> GetById(Guid id)
    {
        return await _mediator.Send(new PatientByIdQuery(id));
    }

    [HttpGet("documentNumber/{documentNumber}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<PatientDto> GetByDocumentNumber(string documentNumber)
    {
        return await _mediator.Send(new PatientByDocumentNumberQuery(documentNumber));
    }

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