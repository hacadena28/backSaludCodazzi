using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetCancel
{
    public class AppointmetCancelCommandHandler : IRequestHandler<AppointmetCancelCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmetCancelCommandHandler(AppointmentService appointmentService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmetCancelCommand request,
            CancellationToken cancellationToken)
        {
            await _appointmentService.CancelAppointment(
                request.Id);
            return Unit.Value;
        }
    }
}