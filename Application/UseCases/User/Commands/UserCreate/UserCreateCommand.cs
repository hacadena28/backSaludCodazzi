using Application.UseCases.User.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.User.Commands.UserCreate;

public record UserCreateCommand(
    string Identification, string Password, Role Role, Guid PersonId, Domain.Entities.Person Person
) : IRequest<UserDtoEmpty>;