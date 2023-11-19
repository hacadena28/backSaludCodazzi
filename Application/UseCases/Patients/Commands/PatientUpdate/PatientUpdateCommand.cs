namespace Application.UseCases.Patients.Commands.PatientUpdate
{
    public record PatientUpdateCommand(Guid Id, string FirstName, string SecondName, string LastName,
        string SecondLastName, string Email, string Phone,
        string Address) : IRequest;
}