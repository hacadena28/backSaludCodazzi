using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;

namespace Api.Examples.MedicalHistoryExamples
{
    public class GetMedicalHistoryQueryExample : IMultipleExamplesProvider<PaginationMedicalHistoryQuery>
    {
        public IEnumerable<SwaggerExample<PaginationMedicalHistoryQuery>> GetExamples()
        {
            var medicalHistoryQuery = new PaginationMedicalHistoryQuery();
            yield return SwaggerExample.Create("MedicalHistoryQuery", medicalHistoryQuery);
        }
    }
}