using Api.Examples.AppointmentExamples;
using Api.Filters;
using Application.Common.Exceptions;
using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Commands.AppointmentsCreate;
using Application.UseCases.Appointments.Commands.AppointmentsDelete;
using Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetChangeState;
using Application.UseCases.Appointments.Queries.GetAppointmentByDoctorId;
using Application.UseCases.Appointments.Queries.GetAppointmentByID;
using Application.UseCases.Appointments.Queries.GetAppointmentByPatientId;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByDay;
using Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByMonth;
using Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByWeek;
using Domain;
using Domain.Enums;
using Messages = Application.Messages;

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

    [HttpGet("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<AppointmentDto> GetById(Guid id)
    {
        return await _mediator.Send(new AppointmentByIdQuery(id));
    }

    [HttpGet("doctor/{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<AppointmentDto>> GetAppointmentByDoctorId(Guid id, int page = 1,
        int recordsPerPage = 20)
    {
        return await _mediator.Send(new AppointmentByDoctorIdQuery(id)
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpGet("patient/{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<ResponsePagination<AppointmentDto>> GetAppointmentByPatinetId(Guid id, int page = 1,
        int recordsPerPage = 20)
    {
        return await _mediator.Send(new AppointmentByPatientIdQuery(id)
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        });
    }

    [HttpGet("day/{date:datetime}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<List<AppointmentDto>> GetAppointmentsForDoctorByDayQuery(Guid doctorId, DateTime date)
    {
        return await _mediator.Send(new AppointmentsForDoctorByDayQuery(doctorId, date)
        );
    }

    [HttpGet("month/{date:datetime}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task<List<AppointmentDto>> GetAppointmentsForDoctorByMonthQuery(Guid doctorId, DateTime date)
    {
        return await _mediator.Send(new AppointmentsForDoctorByMonthQuery(doctorId,date)
        );
    }


    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task AppointmentChangeState(AppointmetChangeStateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException(Messages.IdDoNotMatch);
        }

        await _mediator.Send(command);
    }


    [HttpDelete("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new AppointmentDeleteCommand(id));
}