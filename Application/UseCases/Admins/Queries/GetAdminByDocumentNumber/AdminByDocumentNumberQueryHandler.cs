using Application.UseCases.Admins.Queries.GetAdmin;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Admins.Queries.GetAdminByDocumentNumber;

public class AdminByDocumentNumberQueryHandler : IRequestHandler<AdminByDocumentNumberQuery, AdminDto>
{
    private readonly IGenericRepository<Admin> _repository;
    private readonly AdminService _adminServices;
    private readonly IMapper _mapper;

    public AdminByDocumentNumberQueryHandler(IGenericRepository<Admin>? repository, AdminService adminServices,
        IMapper mapper) =>
        (_repository, _adminServices, _mapper) = (repository, adminServices, mapper);

    public async Task<AdminDto> Handle(AdminByDocumentNumberQuery request, CancellationToken cancellationToken)
    {
        var adminFilterById = await _adminServices.GetAdminByDocumentNumber(request.DocumentNumber);
        var data = _mapper.Map<AdminDto>(adminFilterById);
        return data;
    }
}