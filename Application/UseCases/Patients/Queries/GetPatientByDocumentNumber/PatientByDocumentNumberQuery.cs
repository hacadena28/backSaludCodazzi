using Application.UseCases.Patients.Queries.GetPatient;

namespace Application.UseCases.Patients.Queries.GetPatientByDocumentNumber;

public record PatientByDocumentNumberQuery(string DocumentNumber) : IRequest<PatientDto>;