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

    public async Task<Eps> GetById(Eps eps)
    {
        return await _epsRepository.GetByIdAsync(eps.Id);
    }

    public async Task UpdatedEps(Eps eps)
    {
        eps = await UpdateState(eps);
        await _epsRepository.UpdateAsync(eps);
    }

    public async Task DeleteEps(Eps eps)
    {
        await _epsRepository.DeleteAsync(eps);
    }

    private async Task<Eps> UpdateState(Eps eps)
    {
        var epsRequest = await _epsRepository.GetByIdAsync(eps.Id);
        if (eps.State != epsRequest.State) epsRequest.ChangeState();
        return epsRequest;
    }
}