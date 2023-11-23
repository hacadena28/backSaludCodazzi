using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentUpdate.AppointmetReschedule
{
    public class AppointmetRescheduleCommandHandler : IRequestHandler<AppointmetRescheduleCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmetRescheduleCommandHandler(AppointmentService appointmentService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmetRescheduleCommand request,
            CancellationToken cancellationToken)
        {
            await _appointmentService.RescheduleAppointment(
                request.Id, request.NewDate);
            return Unit.Value;
        }
    }
}