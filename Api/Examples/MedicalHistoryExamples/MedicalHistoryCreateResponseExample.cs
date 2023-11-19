using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.MedicalHistoryExamples
{
    public class MedicalHistoryCreateResponseExample : IMultipleExamplesProvider<Unit>
    {
        public IEnumerable<SwaggerExample<Unit>> GetExamples()
        {
            yield return SwaggerExample.Create("crearAlarmaRequest", Unit.Value);
        }
    }
}