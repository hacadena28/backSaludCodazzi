using Api.Filters;
using Application;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Admins.Commands.AdminUpdate;
using Application.UseCases.Admins.Queries.GetAdmin;
using Application.UseCases.Admins.Queries.GetAdminByDocumentNumber;
using Application.UseCases.Admins.Queries.GetAdminByID;
using Application.UseCases.Users.Queries.GetPaginationUser;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator) => _mediator = mediator;


    [HttpGet]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AdminDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<AdminDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationAdminQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AdminDto), StatusCodes.Status200OK)]
    public async Task<AdminDto> GetById(Guid id)
    {
        return await _mediator.Send(new AdminByIdQuery(id));
    }

    [HttpGet("documentNumber/{documentNumber}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<AdminDto> GetByDocumentNumber(string documentNumber)
    {
        return await _mediator.Send(new AdminByDocumentNumberQuery(documentNumber));
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task Update(AdminUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException(Messages.IdDoNotMatch);
        }

        await _mediator.Send(command);
    }
}