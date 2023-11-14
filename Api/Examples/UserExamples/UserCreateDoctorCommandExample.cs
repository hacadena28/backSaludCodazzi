using Application.UseCases.Users.Commands.UserCreateDoctor;
using Domain.Enums;

namespace Api.Examples.UserExamples
{
    public class UserCreateDoctorCommandExample : IMultipleExamplesProvider<UserCreateDoctorCommand>
    {
        public IEnumerable<SwaggerExample<UserCreateDoctorCommand>> GetExamples()
        {
            var userCommand = new UserCreateDoctorCommand(
                "StrongPassword",
                new DoctorCreateCommand(
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
                    "Specialization1"
                )
            );
            yield return SwaggerExample.Create("userCreateCommand", userCommand);
        }
    }
}