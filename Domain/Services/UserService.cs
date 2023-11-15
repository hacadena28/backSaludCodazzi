using Domain.Entities;
using Domain.Exceptions;
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

    public async Task<User> GetById(User user)
    {
        return await _userRepository.GetByIdAsync(user.Id);
    }

    public async Task UpdatedUser(User user)
    {
        user = await ChangePassword(user);
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUser(User user)
    {
        await _userRepository.DeleteAsync(user);
    }

    private async Task<User> ChangePassword(User user)
    {
        var userRequest = await _userRepository.GetByIdAsync(user.Id);
        if (user.Password != userRequest.Password) userRequest.ChangePassword(user.Password);
        else throw new ThePasswordHasToBeDifferent(Messages.ThePasswordHasToBeDifferent);
        return userRequest;
    }
}