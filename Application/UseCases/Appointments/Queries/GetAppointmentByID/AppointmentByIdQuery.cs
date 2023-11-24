using Application.UseCases.Appointments.Queries.GetAppointments;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByID;

public record AppointmentByIdQuery(Guid Id) : IRequest<AppointmentDto>;