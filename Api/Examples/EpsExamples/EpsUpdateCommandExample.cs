using Application.UseCases.Eps.Commands.EpsUpdate;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.EpsExamples
{
    public class EpsUpdateCommandExample : IMultipleExamplesProvider<EpsChangeStateCommand>
    {
        public IEnumerable<SwaggerExample<EpsChangeStateCommand>> GetExamples()
        {
            var epsCommand = new EpsChangeStateCommand(
                new Guid()
            );
            yield return SwaggerExample.Create("epsUpdateCommand", epsCommand);
        }
    }
}