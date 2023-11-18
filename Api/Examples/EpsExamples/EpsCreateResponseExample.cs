namespace Api.Examples.EpsExamples
{
    public class EpsCreateResponseExample : IMultipleExamplesProvider<Unit>
    {
        public IEnumerable<SwaggerExample<Unit>> GetExamples()
        {
            yield return SwaggerExample.Create("crearAlarmaRequest", Unit.Value);
        }
    }
}