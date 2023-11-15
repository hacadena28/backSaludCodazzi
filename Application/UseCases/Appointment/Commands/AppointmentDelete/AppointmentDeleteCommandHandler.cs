using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointment.Commands.AppointmentDelete
{
    public class AppointmentDeleteCommandHandler : IRequestHandler<AppointmentDeleteCommand, EmptyAppointmentDto>
    {
        private readonly AppointmentService _epsService;
        private readonly IGenericRepository<Domain.Entities.Appointment> _epsRepository;

        public AppointmentDeleteCommandHandler(AppointmentService epsService,
            IGenericRepository<Domain.Entities.Appointment> epsRepository, IMapper mapper)
        {
            _epsService = epsService ?? throw new ArgumentNullException(nameof(epsService));
            _epsRepository = epsRepository ?? throw new ArgumentNullException(nameof(epsRepository));
        }

        public async Task<EmptyAppointmentDto> Handle(AppointmentDeleteCommand request,
            CancellationToken cancellationToken)
        {
            var existingAppointment = await _epsRepository.GetByIdAsync(request.Id);

            if (existingAppointment == null)
                return new EmptyAppointmentDto();
            else
            {
                await _epsService.DeleteAppointment(existingAppointment);
                return new EmptyAppointmentDto();
            }
        }
    }
}