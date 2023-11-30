using Application.UseCases.Users.Commands.UserCreateAdmin;
using Domain.Enums;

namespace Api.Examples.UserExamples
{
    public class UserCreateAdminCommandExample : IMultipleExamplesProvider<UserCreateAdminCommand>
    {
        public IEnumerable<SwaggerExample<UserCreateAdminCommand>> GetExamples()
        {
            var userCommand = new UserCreateAdminCommand(
                "StrongPassword",
                new AdminCreateCommand(
                    "Jane",
                    "Doe",
                    "Johnson",
                    "Brown",
                    TypeDocument.IdentificationCard,
                    "23789012",
                    "jane.doe@example.com",
                    "9876543210",
                    "456 Oak Street",
                    new DateTime(1985, 5, 10))
            );
            yield return SwaggerExample.Create("userCreateCommand", userCommand);
        }
    }
}