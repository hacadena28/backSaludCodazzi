using Application.UseCases.Epses.Commands.EpsCreate;

namespace Api.Examples.EpsExamples
{
    public class EpsCreateCommandExample : IMultipleExamplesProvider<EpsCreateCommand>
    {
        public IEnumerable<SwaggerExample<EpsCreateCommand>> GetExamples()
        {
            var epsCommand = new EpsCreateCommand(
                "Cosalud"
            );
            yield return SwaggerExample.Create("epsCreateCommand", epsCommand);
        }
    }
}