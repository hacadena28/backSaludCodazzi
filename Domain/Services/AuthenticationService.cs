using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;

[DomainService]
public class AuthenticationService
{
    private readonly UserService _userService;

    public AuthenticationService(UserService userService)
    {
        _userService = userService;
    }

    public async Task<bool> ValidateUserCredentials(string documentNumber, string password)
    {
        var userSearched = await _userService.GetUsersAdminByDocumentNumber(documentNumber);
        if (userSearched == null)
        {
            userSearched = await _userService.GetUsersDoctorByDocumentNumber(documentNumber);
        }
        else if (userSearched == null)
        {
            userSearched = await _userService.GetUsersPatientByDocumentNumber(documentNumber);
        }
        else
        {
            throw new UserNotExist(Messages.UserNotExist);
        }

        if (
            userSearched.Password != password)
        {
            throw new IncorrectCredentials(Messages.IncorrectCredentials);
        }

        return true;
    }
}