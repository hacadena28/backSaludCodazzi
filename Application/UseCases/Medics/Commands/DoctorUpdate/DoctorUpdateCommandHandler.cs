using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Medics.Commands.DoctorUpdate
{
    public class DoctorUpdateCommandHandler : IRequestHandler<DoctorUpdateCommand>
    {
        private readonly DoctorService _doctorService;
        private readonly IGenericRepository<Doctor> _doctorRepository;

        public DoctorUpdateCommandHandler(DoctorService doctorService,
            IGenericRepository<Doctor> doctorRepository)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }

        public async Task<Unit> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
        {
            await _doctorService.UpdateDoctor(request.Id,
                request.FirstName,
                request.SecondName,
                request.LastName,
                request.SecondLastName,
                request.Email,
                request.Phone,
                request.Address
            );

            return Unit.Value;
        }
    }
}