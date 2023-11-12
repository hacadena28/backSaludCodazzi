namespace Application.UseCases.Users.Queries.GetUser;

public record UserQuery : IRequest<List<UserDto>>;