using Application.UseCases.Users.Queries.GetPaginationUser;

namespace Api.Examples.UserExamples
{
    public class GetUserQueryExample : IMultipleExamplesProvider<PaginationUserQuery>
    {
        public IEnumerable<SwaggerExample<PaginationUserQuery>> GetExamples()
        {
            var userQuery = new PaginationUserQuery();
            yield return SwaggerExample.Create("userQuery", userQuery);
        }
    }
}