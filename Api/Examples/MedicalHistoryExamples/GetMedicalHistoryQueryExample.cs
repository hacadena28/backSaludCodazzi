using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

namespace Api.Examples.MedicalHistoryExamples
{
    public class GetMedicalHistoryQueryExample : IMultipleExamplesProvider<MedicalHistoryQuery>
    {
        public IEnumerable<SwaggerExample<MedicalHistoryQuery>> GetExamples()
        {
            var medicalHistoryQuery = new MedicalHistoryQuery();
            yield return SwaggerExample.Create("MedicalHistoryQuery", medicalHistoryQuery);
        }
    }
}