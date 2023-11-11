namespace Application.UseCases.Patient.Queries.GetPatient;

public record PatientQuery : IRequest<List<PatientDto>>;