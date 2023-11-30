using Application.Common.Exceptions;
using Application.UseCases.Users.Commands.UserCreateAdmin;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreateAdmin;

public class UserCreateAdminCommandHandler : IRequestHandler<UserCreateAdminCommand>
{
    private readonly UserService _userService;
    private readonly IGenericRepository<Admin> _adminRepository;
    private readonly AdminService _adminService;

    public UserCreateAdminCommandHandler(UserService userService, IGenericRepository<Admin> adminRepository,
        AdminService adminService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
    }

    public async Task<Unit> Handle(UserCreateAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = new Admin(
            request.Admin.FirstName.Trim(),
            request.Admin.SecondName.Trim(),
            request.Admin.LastName.Trim(),
            request.Admin.SecondLastName.Trim(),
            request.Admin.DocumentType,
            request.Admin.DocumentNumber.Trim(),
            request.Admin.Email.Trim(),
            request.Admin.Phone.Trim(),
            request.Admin.Address.Trim(),
            request.Admin.Birthdate
        );

        var searchedAdmin = await _adminService.GetAdminByDocumentNumber(request.Admin.DocumentNumber);
        if (searchedAdmin != null)
        {
            throw new AlreadyExistException(Domain.Messages.AlredyExistException);
        }

        var user = new User(request.Password.Trim(), Role.Admin, admin);
        await _adminRepository.AddAsync(admin);
        await _userService.CreateUser(user);
        return Unit.Value;
    }
}