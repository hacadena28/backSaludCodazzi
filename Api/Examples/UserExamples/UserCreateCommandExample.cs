using Application.UseCases.User.Commands.UserCreate;
using Domain.Entities;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.UserExamples
{
    public class UserCreateCommandExample : IMultipleExamplesProvider<UserCreateCommand>
    {
        public IEnumerable<SwaggerExample<UserCreateCommand>> GetExamples()
        {
            var id = new Guid();
            var _firstName = "heli";
            var _secondName = "Alberto";
            var _lastName = "Cadena";
            var _secondLastName = "Arenilla";
            var _documentType = TypeDocument.IdentificationCard;
            var _documentNumber = "1007824012";
            var _email = "Heli@gmail.com";
            var _phone = 3206870778;
            var _address = "calle 18D";
            var _birthdate = new DateTime(2001, 04, 28);

            var userCommand = new UserCreateCommand(
                "1007824012",
                "1007824012",
                Role.Patient,
                id
                ,
                new Patient(_firstName, _secondName, _lastName, _secondLastName, _documentType, _documentNumber, _email,
                    _phone, _address, _birthdate)
            );

            yield return SwaggerExample.Create("userCreateCommand", userCommand);
        }
    }
}