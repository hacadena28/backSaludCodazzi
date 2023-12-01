namespace Application.UseCases.Epses.Queries.GetEpsNormal;

public record GetAllEpsQuery : IRequest<IEnumerable<EpsNormalDto>>;