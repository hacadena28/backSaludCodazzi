using Application.UseCases.User.Queries.GetUser;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.UserExamples
{
    public class UserCreateResponseExample : IMultipleExamplesProvider<UserDtoEmpty>
    {
        public IEnumerable<SwaggerExample<UserDtoEmpty>> GetExamples()
        {
            var userDtoEmpy = new UserDtoEmpty();
            yield return SwaggerExample.Create("crearAlarmaRequest", userDtoEmpy);
        }
    }
}