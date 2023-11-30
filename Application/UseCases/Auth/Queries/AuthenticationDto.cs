using Domain.Enums;

namespace Application.UseCases.Auth.Queries;

public record AuthenticationDto(Guid userId, string DocumentoNumber, string Token, Role role);