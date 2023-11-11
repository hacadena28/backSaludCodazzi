using Application.UseCases.User.Queries.GetUser;
using Domain.Enums;
using Domain.Services;

namespace Application.UseCases.Users.Commands.UserCreate;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserDtoEmpty>
{
    private readonly UserService _service;
    private readonly IMapper _mapper;

    public UserCreateCommandHandler(UserService service, IMapper mapper)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<UserDtoEmpty> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        var patient = new Domain.Entities.Patient(
            request.Person.FirstName,
            request.Person.SecondName,
            request.Person.LastName,
            request.Person.SecondLastName,
            request.Person.DocumentType,
            request.Person.DocumentNumber,
            request.Person.Email,
            request.Person.Phone,
            request.Person.Address,
            request.Person.Birthdate
        );
        var user = new Domain.Entities.User(request.Password, Role.Patient, patient);
        return new UserDtoEmpty();
    }
}