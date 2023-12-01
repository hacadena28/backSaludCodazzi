using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistoryByID;

public class MedicalHistoryByIdQueryHandler : IRequestHandler<MedicalHistoryByIdQuery, MedicalHistoryDto>
{
    private readonly IGenericRepository<MedicalHistory> _repository;
    private readonly MedicalHistoryService _medicalHistoryServices;
    private readonly IMapper _mapper;

    public MedicalHistoryByIdQueryHandler(IGenericRepository<MedicalHistory>? repository,
        MedicalHistoryService medicalHistoryServices,
        IMapper mapper) =>
        (_repository, _medicalHistoryServices, _mapper) = (repository, medicalHistoryServices, mapper);

    public async Task<MedicalHistoryDto> Handle(MedicalHistoryByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalHistoryFilterById = await _medicalHistoryServices.GetById(request.Id);
        var data = _mapper.Map<MedicalHistoryDto>(medicalHistoryFilterById);
        return data;
    }
}