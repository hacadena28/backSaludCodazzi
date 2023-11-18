namespace Application.UseCases.Epses.Commands.EpsCreate;

public record EpsCreateCommand(
    string Name
) : IRequest<Unit>;