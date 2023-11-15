using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Eps.Commands.EpsDelete
{
    public record EpsDeleteCommand(Guid Id):IRequest<EmptyEpsDto> ;
}