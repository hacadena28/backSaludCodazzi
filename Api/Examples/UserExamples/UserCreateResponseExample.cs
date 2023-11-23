namespace Api.Examples.UserExamples
{
    public class UserCreateResponseExample : IMultipleExamplesProvider<Unit>
    {
        public IEnumerable<SwaggerExample<Unit>> GetExamples()
        {
            yield return SwaggerExample.Create("crearAlarmaRequest", Unit.Value);
        }
    }
}