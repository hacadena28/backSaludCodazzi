using Application.UseCases.Eps.Commands.EpsCreate;
using Application.UseCases.Eps.Queries.GetEps;
using Application.UseCases.Users.Commands.UserCreatePatient;
using Domain.Entities;
using Domain.Enums;

namespace Api.Examples.UserExamples
{
    public class UserCreatePatientCommandExample : IMultipleExamplesProvider<UserCreatePatientCommand>
    {
        public IEnumerable<SwaggerExample<UserCreatePatientCommand>> GetExamples()
        {
            var userCommand = new UserCreatePatientCommand(
                "StrongPassword",
                new PatientCreateCommand(
                    "Jane",
                    "Doe",
                    "Johnson",
                    "Brown",
                    TypeDocument.IdentificationCard,
                    "23789012",
                    "jane.doe@example.com",
                    "9876543210",
                    "456 Oak Street",
                    new DateTime(1985, 5, 10),
                    new EpsDto(new Guid(), "cosalud444", EpsState.Active)
                )
            );
            yield return SwaggerExample.Create("userCreateCommand", userCommand);
        }
    }
}