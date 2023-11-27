using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetChangeState
{
    public class AppointmetChangeStateCommandHandler : IRequestHandler<AppointmetChangeStateCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmetChangeStateCommandHandler(AppointmentService appointmentService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmetChangeStateCommand request,
            CancellationToken cancellationToken)
        {
            await _appointmentService.ChangeStateAppointment(
                request.Id, request.State,
                request.NewDate);
            return Unit.Value;
        }
    }
}