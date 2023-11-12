using Application.UseCases.Users.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Users.Commands.UserDelete
{
    public record UserDeleteCommand(Guid Id):IRequest<UserDtoEmpty> ;
}