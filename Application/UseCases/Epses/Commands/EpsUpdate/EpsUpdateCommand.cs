namespace Application.UseCases.Epses.Commands.EpsUpdate
{
    public record EpsUpdateCommand(Guid Id, string newName) : IRequest<Unit>;
}