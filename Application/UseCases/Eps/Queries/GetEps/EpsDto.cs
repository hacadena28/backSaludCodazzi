using Domain.Enums;

namespace Application.UseCases.Eps.Queries.GetEps;

public record EpsDto(Guid Id, string Name, EpsState State);