using Domain.Enums;

namespace Application.UseCases.Eps.Queries.GetEps;

public record EpsDto(Guid id, string name, EpsState state);