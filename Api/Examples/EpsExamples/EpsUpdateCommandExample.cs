using Application.UseCases.Eps.Commands.EpsUpdate;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.EpsExamples
{
    public class EpsUpdateCommandExample : IMultipleExamplesProvider<EpsUpdateCommand>
    {
        public IEnumerable<SwaggerExample<EpsUpdateCommand>> GetExamples()
        {
            var epsCommand = new EpsUpdateCommand(
                new Guid(),
                "Cosalud",
                EpsState.Active
            );
            yield return SwaggerExample.Create("epsUpdateCommand", epsCommand);
        }
    }
}