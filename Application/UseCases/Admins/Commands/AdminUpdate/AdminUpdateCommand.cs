namespace Application.UseCases.Admins.Commands.AdminUpdate
{
    public record AdminUpdateCommand(Guid Id, string? FirstName, string? SecondName, string? LastName,
        string? SecondLastName, string? Email, string? Phone,
        string? Address) : IRequest;
}