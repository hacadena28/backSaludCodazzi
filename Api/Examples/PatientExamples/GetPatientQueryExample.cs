using Application.UseCases.Patient.Queries.GetPatient;

namespace Api.Examples.PatientExamples
{
    public class GetPatientQueryExample : IMultipleExamplesProvider<PatientQuery>
    {
        public IEnumerable<SwaggerExample<PatientQuery>> GetExamples()
        {
            var patientQuery = new PatientQuery();
            yield return SwaggerExample.Create("patientQuery", patientQuery);
        }
    }
}