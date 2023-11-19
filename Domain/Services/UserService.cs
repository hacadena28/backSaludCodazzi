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

    public async Task<User> GetById(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task UpdateUser(Guid userId, string newPassword)
    {
        var userSearched = await _userRepository.GetByIdAsync(userId);
        if (newPassword != userSearched.Password)
        {
            userSearched.ChangePassword(newPassword);
        }
        else
        {
            throw new ThePasswordHasToBeDifferent(Messages.ThePasswordHasToBeDifferent);
        }

        await _userRepository.UpdateAsync(userSearched);
    }

    public async Task DeleteUser(Guid id)
    {
        var userSearched = await _userRepository.GetByIdAsync(id);
        _ = userSearched ?? throw new CoreBusinessException(Messages.AlredyExistException);
        await _userRepository.DeleteAsync(userSearched);
    }
}