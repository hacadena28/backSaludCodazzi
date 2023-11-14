using Application.UseCases.Doctor.Queries.GetDoctor;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Doctor.Commands.DoctorUpdate
{
    public class DoctorUpdateCommandHandler : IRequestHandler<DoctorUpdateCommand, DoctorDto>
    {
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entities.Doctor> _doctorRepository;

        public DoctorUpdateCommandHandler(DoctorService doctorService,
            IGenericRepository<Domain.Entities.Doctor> doctorRepository, IMapper mapper)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        }

        public async Task<DoctorDto> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
        {
            var existingDoctor = await _doctorRepository.GetByIdAsync(request.Id);

            if (existingDoctor == null)
            {
                throw new Exception("El paciente no se encontró o no existe.");
            }

            if (existingDoctor.Id == request.Id)
            {
                existingDoctor.FirstName = request.firstName;
                existingDoctor.SecondName = request.secondName;
                existingDoctor.LastName = request.lastName;
                existingDoctor.SecondLastName = request.secondLastName;
                existingDoctor.DocumentType = request.documentType;
                existingDoctor.DocumentNumber = request.documentNumber;
                existingDoctor.Email = request.email;
                existingDoctor.Phone = request.phone;
                existingDoctor.Address = request.address;
                existingDoctor.Birthdate = request.birthdate;
                existingDoctor.Specialization = request.specialization;


                await _doctorService.UpdateDoctor(existingDoctor);

                var updatedDoctor = await _doctorRepository.GetByIdAsync(request.Id);

                return _mapper.Map<DoctorDto>(updatedDoctor);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}