namespace Application.UseCases.User.Queries.GetUser;

public record UserQuery : IRequest<List<UserDto>>;