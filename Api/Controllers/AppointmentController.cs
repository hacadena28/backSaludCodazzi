using Api.Examples.AppointmentExamples;
using Api.Filters;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Commands.AppointmentsCreate;
using Application.UseCases.Appointments.Commands.AppointmentsDelete;
using Application.UseCases.Appointments.Commands.AppointmentUpdate;
using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController
{
    private readonly IMediator _mediator;

    public AppointmentController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [SwaggerRequestExample(typeof(AppointmentCreateCommand), typeof(AppointmentCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AppointmentCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task Create(AppointmentCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<AppointmentDto>> Get(int page = 1, int recordsPerPage = 20)
    {
        return await _mediator.Send(new PaginationAppointmentQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task Update(AppointmentUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException("The id of route no is the same of the command");
        }

        await _mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new AppointmentDeleteCommand(id));
}