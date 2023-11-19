using Domain.Ports;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

public class MedicalHistoryQueryHandler : IRequestHandler<MedicalHistoryQuery, List<MedicalHistoryDto>>
{
    private readonly IGenericRepository<Domain.Entities.MedicalHistory> _repository;
    private readonly IMapper _mapper;

    public MedicalHistoryQueryHandler(IGenericRepository<Domain.Entities.MedicalHistory>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<MedicalHistoryDto>> Handle(MedicalHistoryQuery request, CancellationToken cancellationToken)
    {
        var medicalHistory = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<MedicalHistoryDto>>(medicalHistory);
    }
}