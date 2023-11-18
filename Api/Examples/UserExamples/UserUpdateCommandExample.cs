using Application.UseCases.Users.Commands.UserCreatePatient;
using Application.UseCases.Users.Commands.UserUpdate;
using Domain.Entities;
using Domain.Enums;

namespace Api.Examples.UserExamples
{
    public class UserUpdatePatientCommandExample : IMultipleExamplesProvider<UserUpdateCommand>
    {
        public IEnumerable<SwaggerExample<UserUpdateCommand>> GetExamples()
        {
            var userCommand = new UserUpdateCommand(
                new Guid(),
                "StrongPassword"
            );
            yield return SwaggerExample.Create("userUpdateCommand", userCommand);
        }
    }
}