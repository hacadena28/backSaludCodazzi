using Application.UseCases.Users.Queries.GetPaginationUser;
using Application.UseCases.Users.Queries.GetUserByID;
using Domain.Entities;
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
        var userFilterById = await _userServices.GetUsersDoctorByDocumentNumber(request.DocumentNumber);
        var data = _mapper.Map<UserDto>(userFilterById);
        return data;
    }
}