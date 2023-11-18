namespace Application.UseCases.Epses.Commands.EpsUpdate
{
    public record EpsChangeStateCommand(Guid Id, string newName) : IRequest<Unit>;
}