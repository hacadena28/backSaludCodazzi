using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class AdminService
{
    private readonly IGenericRepository<Admin> _adminRepository;

    public AdminService(IGenericRepository<Admin> adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<Admin> GetById(Guid adminId)
    {
        return await _adminRepository.GetByIdAsync(adminId);
    }


    public async Task<Admin> GetAdminByDocumentNumber(string documentNumber)
    {
        var response = await _adminRepository.GetPagedFilterAsync(
            page: 1,
            pageSize: 20,
            filter: d => d.DocumentNumber == documentNumber,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false
        );

        return response.Records.FirstOrDefault();
    }

    public async Task UpdateAdmin(Guid id, string? firstName, string? secondName, string? lastName,
        string? secondLastName, string? email, string? phone,
        string? address)
    {
        var adminSearched = await _adminRepository.GetByIdAsync(id);
        _ = adminSearched ?? throw new CoreBusinessException(Messages.ResourceNotFoundException);
        adminSearched.Update(firstName, secondName, lastName, secondLastName, email, phone, address);
        await _adminRepository.UpdateAsync(adminSearched);
    }
}