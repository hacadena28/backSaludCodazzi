using Application.UseCases.Eps.Queries.GetEps;

namespace Api.Examples.EpsExamples
{
    public class GetEpsQueryExample : IMultipleExamplesProvider<EpsQuery>
    {
        public IEnumerable<SwaggerExample<EpsQuery>> GetExamples()
        {
            var epsQuery = new EpsQuery();
            yield return SwaggerExample.Create("epsQuery", epsQuery);
        }
    }
}