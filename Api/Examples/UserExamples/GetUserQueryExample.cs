using Application.UseCases.User.Queries.GetUser;

namespace Api.Examples.UserExamples
{
    public class GetUserQueryExample : IMultipleExamplesProvider<UserQuery>
    {
        public IEnumerable<SwaggerExample<UserQuery>> GetExamples()
        {
            var userQuery = new UserQuery();
            yield return SwaggerExample.Create("userQuery", userQuery);
        }
    }
}