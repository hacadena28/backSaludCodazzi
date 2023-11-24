using Application.UseCases.Epses.Queries.GetEps;

namespace Application.UseCases.Epses.Queries.GetEpsByID;

public record EpsByIdQuery(Guid Id) : IRequest<EpsDto>;