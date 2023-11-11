using Domain.Entities;
using Domain.Ports;



namespace Domain.Services;

[DomainService]
public class UserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.AddAsync(user);
    }

    public async Task UpdatedUser(User user)
    {
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUser(User user)
    {
        await _userRepository.DeleteAsync(user);
    }
}