using Domain.Entities;
using Domain.Enums;
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

    public async Task<User> ValidateUserCredentials(string documentNumber, string password, Role role)
    {
        User userSearched;
        if (role is Role.Admin)
        {
            userSearched = await _userService.GetUsersAdminByDocumentNumber(documentNumber);
        }
        else if (role is Role.Doctor)
        {
            userSearched = await _userService.GetUsersDoctorByDocumentNumber(documentNumber);
        }
        else if (role is Role.Patient)
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

        return userSearched;
    }
}