using Application.UseCases.Epses.Queries.GetEps;

namespace Api.Examples.EpsExamples
{
    public class GetEpsQueryExample : IMultipleExamplesProvider<PaginationEpsQuery>
    {
        public IEnumerable<SwaggerExample<PaginationEpsQuery>> GetExamples()
        {
            var epsQuery = new PaginationEpsQuery();
            yield return SwaggerExample.Create("epsQuery", epsQuery);
        }
    }
}