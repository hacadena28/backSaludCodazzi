using Api.Filters;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Medics.Commands.DoctorUpdate;
using Application.UseCases.Medics.Queries.GetDoctor;
using Application.UseCases.Medics.Queries.GetDoctorByDocumentNumber;
using Application.UseCases.Medics.Queries.GetDoctorByID;
using Application.UseCases.Medics.Queries.GetEpsNormal;
using Application.UseCases.Users.Queries.GetPaginationUser;

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
    public async Task<ResponsePagination<DoctorDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationDoctorQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }
    
    [HttpGet("all")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
    public async Task<IEnumerable<DoctorNormalDto>> GetAll()
    {
        return await _mediator.Send(new GetAllDoctorQuery());
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
    public async Task<DoctorDto> GetById(Guid id)
    {
        return await _mediator.Send(new DoctorByIdQuery(id));
    }

    [HttpGet("documentNumber/{documentNumber}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<DoctorDto> GetByDocumentNumber(string documentNumber)
    {
        return await _mediator.Send(new DoctorByDocumentNumberQuery(documentNumber));
    }

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