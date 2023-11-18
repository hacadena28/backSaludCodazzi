namespace Application.UseCases.Epses.Commands.EpsDelete
{
    public record EpsDeleteCommand(Guid Id):IRequest<Unit> ;
}