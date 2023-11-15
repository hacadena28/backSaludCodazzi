using Application.UseCases.Eps.Queries.GetEps;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.EpsExamples
{
    public class EpsCreateResponseExample : IMultipleExamplesProvider<EmptyEpsDto>
    {
        public IEnumerable<SwaggerExample<EmptyEpsDto>> GetExamples()
        {
            var epsDtoEmpy = new EmptyEpsDto();
            yield return SwaggerExample.Create("crearAlarmaRequest", epsDtoEmpy);
        }
    }
}