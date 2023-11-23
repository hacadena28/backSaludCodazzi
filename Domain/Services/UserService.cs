using Domain.Entities;
using Domain.Enums;
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

    public async Task<IEnumerable<User>> GetUsersByRole(Role role)
    {
        return await _userRepository.GetAsync(
            filter: u => u.Role == role,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );
    }

    public async Task<PagedResult<User>> GetUsersPaginationByRole(int page, int pageSize, Role role)
    {
        return await _userRepository.GetPagedFilterAsync(
            page,
            pageSize,
            filter: u => u.Role == role,
            orderBy: null,
            includeStringProperties: "Person",
            isTracking: false
        );
    }


    public async Task UpdateUser(Guid userId, string newPassword)
    {
        var userSearched = await _userRepository.GetByIdAsync(userId);
        _ = userSearched ?? throw new CoreBusinessException(Messages.AlredyExistException);
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

    public async Task DeleteUser(User user)
    {
        await _userRepository.DeleteAsync(user);
    }
}