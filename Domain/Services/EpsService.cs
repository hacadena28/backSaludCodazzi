using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;


namespace Domain.Services;

[DomainService]
public class EpsService
{
    private readonly IGenericRepository<Eps> _epsRepository;

    public EpsService(IGenericRepository<Eps> epsRepository)
    {
        _epsRepository = epsRepository;
    }

    public async Task CreateEps(Eps eps)
    {
        await _epsRepository.AddAsync(eps);
    }

    public async Task<Eps> GetById(Guid epsId)
    {
        return await _epsRepository.GetByIdAsync(epsId);
    }

    public async Task<Eps> GetByName(string name)
    {
        var result = await _epsRepository.GetPagedFilterAsync(
            page: 1,
            pageSize: 20,
            filter: e => e.Name == name,
            orderBy: null,
            includeStringProperties: "",
            isTracking: false);

        return result.Records.FirstOrDefault();
    }

    public async Task Update(Guid epsId, string newName)
    {
        var eps = await _epsRepository.GetByIdAsync(epsId);
        _ = eps ?? throw new CoreBusinessException(Messages.ResourceNotFoundException);
        eps.Update(newName);
        await _epsRepository.UpdateAsync(eps);
    }

    public async Task DeleteEps(Eps eps)
    {
        await _epsRepository.DeleteAsync(eps);
    }
}