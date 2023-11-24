using Application.UseCases.Epses.Queries.GetEps;

namespace Application.UseCases.Epses.Queries.GetEpsByName;

public record EpsByNameQuery(string Name) : IRequest<EpsDto>;