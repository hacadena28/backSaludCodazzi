using Application.UseCases.User.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.User.Commands.UserDelete
{
    public record UserDeleteCommand(Guid Id):IRequest<UserDtoEmpty> ;
}