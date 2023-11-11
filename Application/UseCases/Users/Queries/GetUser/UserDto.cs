using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.User.Queries.GetUser;

public record UserDto(Guid id, string identification, string password, Role role);