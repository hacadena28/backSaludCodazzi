namespace Application.UseCases.Appointment.Queries.GetAppointment;

public record AppointmentQuery : IRequest<List<AppointmentDto>>;