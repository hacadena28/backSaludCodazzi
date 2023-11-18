using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Eps.Commands.EpsUpdate
{
    public record EpsChangeStateCommand(Guid Id) : IRequest<Unit>;
}