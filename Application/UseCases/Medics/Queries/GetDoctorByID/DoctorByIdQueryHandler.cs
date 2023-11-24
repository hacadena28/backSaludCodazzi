using Application.UseCases.Medics.Queries.GetDoctor;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Medics.Queries.GetDoctorByID;

public class DoctorByIdQueryHandler : IRequestHandler<DoctorByIdQuery, DoctorDto>
{
    private readonly IGenericRepository<Doctor> _repository;
    private readonly DoctorService _doctorServices;
    private readonly IMapper _mapper;

    public DoctorByIdQueryHandler(IGenericRepository<Doctor>? repository, DoctorService doctorServices,
        IMapper mapper) =>
        (_repository, _doctorServices, _mapper) = (repository, doctorServices, mapper);

    public async Task<DoctorDto> Handle(DoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctorFilterById = await _doctorServices.GetById(request.Id);
        var data = _mapper.Map<DoctorDto>(doctorFilterById);
        return data;
    }
}