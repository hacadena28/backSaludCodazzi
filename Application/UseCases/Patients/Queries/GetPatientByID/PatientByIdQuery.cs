using Application.UseCases.Patients.Queries.GetPatient;
using Application.UseCases.Users.Queries.GetPaginationUser;

namespace Application.UseCases.Patients.Queries.GetPatientByID;

public record PatientByIdQuery(Guid Id) : IRequest<PatientDto>;