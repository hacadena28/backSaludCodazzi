using Application.Common.Exceptions;
using Application.UseCases.Users.Queries.GetPaginationUser;
using Application.UseCases.Users.Queries.GetUserByID;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Users.Queries.GetUserByDocumentNumber;

public class UserByDocumentNumberQueryHandler : IRequestHandler<UserByDocumentNumberQuery, UserDto>
{
    private readonly IGenericRepository<User> _repository;
    private readonly UserService _userServices;
    private readonly IMapper _mapper;

    public UserByDocumentNumberQueryHandler(IGenericRepository<User>? repository, UserService userServices,
        IMapper mapper) =>
        (_repository, _userServices, _mapper) = (repository, userServices, mapper);

    public async Task<UserDto> Handle(UserByDocumentNumberQuery request, CancellationToken cancellationToken)
    {
        User userFilterById = null;
        if (request.role == Role.Doctor)
            userFilterById = await _userServices.GetUsersDoctorByDocumentNumber(request.DocumentNumber);
        else if (request.role == Role.Patient)
            userFilterById = await _userServices.GetUsersPatientByDocumentNumber(request.DocumentNumber);
        else if (request.role == Role.Admin)
            userFilterById = await _userServices.GetUsersAdminByDocumentNumber(request.DocumentNumber);
        if (userFilterById == null)
        {
            throw new EntityNotFound(Messages.EntityNotFound);
        }

        var data = _mapper.Map<UserDto>(userFilterById);
        return data;
    }
}