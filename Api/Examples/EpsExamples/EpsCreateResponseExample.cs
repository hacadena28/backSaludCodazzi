using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.EpsExamples
{
    public class EpsCreateResponseExample : IMultipleExamplesProvider<EpsDtoEmpty>
    {
        public IEnumerable<SwaggerExample<EpsDtoEmpty>> GetExamples()
        {
            var epsDtoEmpy = new EpsDtoEmpty();
            yield return SwaggerExample.Create("crearAlarmaRequest", epsDtoEmpy);
        }
    }
}