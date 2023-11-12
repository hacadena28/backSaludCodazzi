using Application.UseCases.Users.Commands.UserCreate;
using Domain.Entities;
using Domain.Enums;

namespace Api.Examples.UserExamples
{
    public class UserCreateCommandExample : IMultipleExamplesProvider<UserCreateCommand>
    {
        public IEnumerable<SwaggerExample<UserCreateCommand>> GetExamples()
        {
            var userCommand = new UserCreateCommand(
                "StrongPassword",
                Role.Patient,
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
                    new Eps("cosalud")
                )
            );
            yield return SwaggerExample.Create("userCreateCommand", userCommand);
        }
    }
}