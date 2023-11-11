using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Enums;
using Domain.Tests;

namespace Api.Examples.PatientExamples
{
    public class PatientCreateResponseExample : IMultipleExamplesProvider<PatientDtoEmpty>
    {
        public IEnumerable<SwaggerExample<PatientDtoEmpty>> GetExamples()
        {
            var userDtoEmpy = new PatientDtoEmpty();
            yield return SwaggerExample.Create("crearAlarmaRequest", userDtoEmpy);
        }
    }
}