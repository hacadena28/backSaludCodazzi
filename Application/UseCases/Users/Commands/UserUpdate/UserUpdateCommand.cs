using Application.UseCases.Users.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using Domain.Tests;
using MediatR;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public record UserUpdateCommand(Guid Id, string Identification,string Password, Role Role, Guid PersonId) : IRequest<UserDto>;
}