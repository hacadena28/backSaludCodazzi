using Application.Common.Helpers.Pagination;
using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.MedicalHistorys.Queries.GetMedicalHistoryByPatientId;

public class
    MedicalHistoryByPatientIdQueryHandler : IRequestHandler<MedicalHistoryByPatientIdQuery,
        ResponsePagination<MedicalHistoryDto>>
{
    private readonly IGenericRepository<User> _repository;
    private readonly MedicalHistoryService _medicalHistoryServices;
    private readonly IMapper _mapper;

    public MedicalHistoryByPatientIdQueryHandler(IGenericRepository<User> repository,
        MedicalHistoryService medicalHistoryServices,
        IMapper mapper) =>
        (_repository, _medicalHistoryServices, _mapper) = (repository, medicalHistoryServices, mapper);

    public async Task<ResponsePagination<MedicalHistoryDto>> Handle(MedicalHistoryByPatientIdQuery request,
        CancellationToken cancellationToken)
    {
        var medicalHistoryFilterByPatientId =
            await _medicalHistoryServices.GetByPatientId(request.PatientId, request.Page, request.RecordsPerPage);
        var data = _mapper.Map<List<MedicalHistoryDto>>(medicalHistoryFilterByPatientId.Records);

        return new ResponsePagination<MedicalHistoryDto>
        {
            Page = request.Page,
            Records = data,
            TotalPages = medicalHistoryFilterByPatientId.TotalPages,
            TotalRecords = medicalHistoryFilterByPatientId.TotalRecords
        };
    }
}