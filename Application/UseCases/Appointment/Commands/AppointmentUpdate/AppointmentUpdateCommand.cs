using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Appointment.Commands.AppointmentUpdate
{
    public record AppointmentUpdateCommand(Guid Id, DateTime Date, AppointmentState State,TypeAppointment Type, string Description,Guid DoctorId) : IRequest<AppointmentDto>;
}