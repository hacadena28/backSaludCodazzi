using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Eps.Commands.EpsUpdate
{
    public record EpsUpdateCommand(Guid Id, string EpsName, EpsState State) : IRequest<EpsDto>;
}