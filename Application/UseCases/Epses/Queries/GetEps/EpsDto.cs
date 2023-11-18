using Domain.Enums;

namespace Application.UseCases.Epses.Queries.GetEps;

public record EpsDto(Guid Id, string Name, EpsState State);