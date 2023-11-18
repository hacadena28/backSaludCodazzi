namespace Application.UseCases.Patients.Queries.GetPatient;

public record PatientQuery : IRequest<List<PatientDto>>;