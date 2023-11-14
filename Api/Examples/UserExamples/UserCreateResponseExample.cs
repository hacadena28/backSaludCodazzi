using Application.UseCases.Users.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.UserExamples
{
    public class UserCreateResponseExample : IMultipleExamplesProvider<EmptyUserDto>
    {
        public IEnumerable<SwaggerExample<EmptyUserDto>> GetExamples()
        {
            var userDtoEmpy = new EmptyUserDto();
            yield return SwaggerExample.Create("crearAlarmaRequest", userDtoEmpy);
        }
    }
}