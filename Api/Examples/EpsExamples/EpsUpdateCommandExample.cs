using Application.UseCases.Epses.Commands.EpsUpdate;

namespace Api.Examples.EpsExamples
{
    public class EpsUpdateCommandExample : IMultipleExamplesProvider<EpsUpdateCommand>
    {
        public IEnumerable<SwaggerExample<EpsUpdateCommand>> GetExamples()
        {
            var epsCommand = new EpsUpdateCommand(
                new Guid(),
                "SaludTotal"
            );
            yield return SwaggerExample.Create("epsUpdateCommand", epsCommand);
        }
    }
}