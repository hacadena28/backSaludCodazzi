using Application.UseCases.Epses.Commands.EpsUpdate;

namespace Api.Examples.EpsExamples
{
    public class EpsUpdateCommandExample : IMultipleExamplesProvider<EpsChangeStateCommand>
    {
        public IEnumerable<SwaggerExample<EpsChangeStateCommand>> GetExamples()
        {
            var epsCommand = new EpsChangeStateCommand(
                new Guid(),
                "SaludTotal"
            );
            yield return SwaggerExample.Create("epsUpdateCommand", epsCommand);
        }
    }
}