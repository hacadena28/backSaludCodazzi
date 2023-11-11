using Application.UseCases.User.Queries.GetUser;
using Domain.Enums;
using Domain.Tests;
using MediatR;

namespace Application.UseCases.User.Commands.UserUpdate
{
    public record UserUpdateCommand(Guid Id, string Identification,string Password, Role Role, Guid PersonId) : IRequest<UserDto>;
}