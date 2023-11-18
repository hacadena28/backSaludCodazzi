using Domain.Entities;
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

    public async Task ChangeState(Eps eps)
    {
        eps.ChangeState();
        await _epsRepository.UpdateAsync(eps);
    }

    public async Task DeleteEps(Eps eps)
    {
        await _epsRepository.DeleteAsync(eps);
    }
}