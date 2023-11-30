using Application.UseCases.Admins.Queries.GetAdmin;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Admins.Queries.GetAdminByID;

public class AdminByIdQueryHandler : IRequestHandler<AdminByIdQuery, AdminDto>
{
    private readonly IGenericRepository<Admin> _repository;
    private readonly AdminService _adminServices;
    private readonly IMapper _mapper;

    public AdminByIdQueryHandler(IGenericRepository<Admin>? repository, AdminService adminServices,
        IMapper mapper) =>
        (_repository, _adminServices, _mapper) = (repository, adminServices, mapper);

    public async Task<AdminDto> Handle(AdminByIdQuery request, CancellationToken cancellationToken)
    {
        var adminFilterById = await _adminServices.GetById(request.Id);
        var data = _mapper.Map<AdminDto>(adminFilterById);
        return data;
    }
}