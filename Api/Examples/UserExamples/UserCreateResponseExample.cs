using Application.UseCases.Users.Queries.GetUser;

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