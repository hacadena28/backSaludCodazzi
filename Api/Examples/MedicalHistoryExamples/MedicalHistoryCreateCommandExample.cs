using Application.UseCases.MedicalHistorys.Commands.MedicalHistoryCreate;

namespace Api.Examples.MedicalHistoryExamples
{
    public class MedicalHistoryCreateCommandExample : IMultipleExamplesProvider<MedicalHistoryCreateCommand>
    {
        public IEnumerable<SwaggerExample<MedicalHistoryCreateCommand>> GetExamples()
        {
            var medicalHistoryCommand = new MedicalHistoryCreateCommand(
                DateTime.Now,
                "Dolor de muelas",
                "Caries",
                "limpieza",
                new Guid(),
                new Guid()
            );
            yield return SwaggerExample.Create("medicalHistoryCreateCommand", medicalHistoryCommand);
        }
    }
}