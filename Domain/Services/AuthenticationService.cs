using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class AuthenticationService
{
    private readonly UserService _userService;
    private readonly IGenericRepository<User> _repository;

    public AuthenticationService(UserService userService, IGenericRepository<User> repository)
    {
        _userService = userService;
        _repository = repository;
    }

    public async Task<User> ValidateUserCredentials(string documentNumber, string password)
    {
        var user = (await _repository.GetAsync(
            x => x.Person.DocumentNumber == documentNumber && x.Password == password,
            includeStringProperties: "Person")).FirstOrDefault();
        if (user ==  null)
        {
            throw new IncorrectCredentials(Messages.IncorrectCredentials);
        }
        return user;
    }
}