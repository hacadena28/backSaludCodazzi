using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;

namespace Application.UseCases.Eps.Commands.EpsCreate;

public record EpsCreateCommand(
    string Name
) : IRequest<EmptyEpsDto>;