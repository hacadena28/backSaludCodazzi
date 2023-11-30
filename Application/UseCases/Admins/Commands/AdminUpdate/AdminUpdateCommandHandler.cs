using Application.UseCases.Medics.Commands.DoctorUpdate;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Admins.Commands.AdminUpdate
{
    public class AdminUpdateCommandHandler : IRequestHandler<DoctorUpdateCommand>
    {
        private readonly DoctorService _doctorService;
        private readonly IGenericRepository<Doctor> _doctorRepository;

        public AdminUpdateCommandHandler(DoctorService doctorService,
            IGenericRepository<Doctor> doctorRepository)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }

        public async Task<Unit> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
        {
            await _doctorService.UpdateDoctor(request.Id,
                request.FirstName?.Trim(),
                request.SecondName?.Trim(),
                request.LastName?.Trim(),
                request.SecondLastName?.Trim(),
                request.Email?.Trim(),
                request.Phone?.Trim(),
                request.Address?.Trim()
            );

            return Unit.Value;
        }
    }
}