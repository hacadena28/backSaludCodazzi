using Domain.Entities;
using Domain.Ports;

namespace Application.UseCases.Medics.Queries.GetEpsNormal;

public class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, IEnumerable<DoctorNormalDto>>
{
    private readonly IGenericRepository<Doctor> _repository;
    private readonly IMapper _mapper;

    public GetAllDoctorQueryHandler(IGenericRepository<Doctor> repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    public async Task<IEnumerable<DoctorNormalDto>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
    {
        return (await _repository.GetAsync()).ToList().ConvertAll( x => new DoctorNormalDto(x.Id, x.FirstName + " " + x.LastName));
    }
}