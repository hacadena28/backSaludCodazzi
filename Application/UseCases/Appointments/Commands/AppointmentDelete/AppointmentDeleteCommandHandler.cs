using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentDelete
{
    public class AppointmentDeleteCommandHandler : IRequestHandler<AppointmentDeleteCommand>
    {
        private readonly AppointmentService _appointmentService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _appointmentRepository;

        public AppointmentDeleteCommandHandler(AppointmentService epsService,
            IGenericRepository<Domain.Entities.Appointment> appointmentRepository)
        {
            _appointmentService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _appointmentRepository =
                appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
        }

        public async Task<Unit> Handle(AppointmentDeleteCommand request,
            CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);
            await _appointmentService.Delete(appointment);
            return Unit.Value;
        }
    }
}