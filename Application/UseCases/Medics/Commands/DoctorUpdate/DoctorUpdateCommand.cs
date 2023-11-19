using Application.UseCases.Medics.Queries.GetDoctor;
using Domain.Enums;

namespace Application.UseCases.Medics.Commands.DoctorUpdate
{
    public record DoctorUpdateCommand(Guid Id, string FirstName, string SecondName, string LastName,
        string SecondLastName, string Email, string Phone,
        string Address) : IRequest;
}