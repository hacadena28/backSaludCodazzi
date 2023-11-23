using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetAttended
{
    public class AppointmetAttendedCommandHandler : IRequestHandler<AppointmetAttendedCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmetAttendedCommandHandler(AppointmentService appointmentService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmetAttendedCommand request,
            CancellationToken cancellationToken)
        {
            await _appointmentService.CancelAppointment(
                request.Id);
            return Unit.Value;
        }
    }
}