using Api.Examples.AppointmentExamples;
using Api.Filters;
using Application.UseCases.Appointment.Commands.AppointmentCreate;
using Application.UseCases.Appointment.Commands.AppointmentDelete;
using Application.UseCases.Appointment.Commands.AppointmentUpdate;
using Application.UseCases.Appointment.Queries.GetAppointment;

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
    public async Task<EmptyAppointmentDto> Create(AppointmentCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(AppointmentQuery), typeof(GetAppointmentQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AppointmentCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<List<AppointmentDto>> Get() => await _mediator.Send(new AppointmentQuery());

    [HttpPut]
    public async Task<AppointmentDto> Update(AppointmentUpdateCommand command)
    {
        var updatedAppointment = await _mediator.Send(command);
        return updatedAppointment;
    }

    [HttpDelete("{id}")]
    public async Task<EmptyAppointmentDto> Delete(Guid id)
    {
        var deleteAppointment = await _mediator.Send(new AppointmentDeleteCommand(id));
        return deleteAppointment;
    }
}