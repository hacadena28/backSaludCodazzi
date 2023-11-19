using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentUpdate
{
    public class AppointmentUpdateCommandHandler : IRequestHandler<AppointmentUpdateCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmentUpdateCommandHandler(AppointmentService appointmentService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
        {
            await _appointmentService.Update(
                request.Id, request.Date, request.State);
            return Unit.Value;
        }
    }
}