using Application.UseCases.User.Queries.GetUser;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.User.Commands.UserDelete
{
    public record UserDeleteCommand(Guid Id):IRequest<UserDtoEmpty> ;
}