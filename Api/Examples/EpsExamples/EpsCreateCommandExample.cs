using Application.UseCases.Eps.Commands.EpsCreate;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.EpsExamples
{
    public class EpsCreateCommandExample : IMultipleExamplesProvider<EpsCreateCommand>
    {
        public IEnumerable<SwaggerExample<EpsCreateCommand>> GetExamples()
        {
            var epsCommand = new EpsCreateCommand(
                "Cosalud",
                EpsState.Active
            );
            yield return SwaggerExample.Create("epsCreateCommand", epsCommand);
        }
    }
}