using Api.Examples.AppointmentExamples;
using Api.Filters;
using Application.Common.Exceptions;
using Application.UseCases.Appointment.Queries.GetAppointment;
using Application.UseCases.Appointments.Commands.AppointmentCreate;
using Application.UseCases.Appointments.Commands.AppointmentDelete;
using Application.UseCases.Appointments.Commands.AppointmentUpdate;

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
    [SwaggerRequestExample(typeof(AppointmentQuery), typeof(GetAppointmentQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AppointmentCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<List<AppointmentDto>> Get() => await _mediator.Send(new AppointmentQuery());

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