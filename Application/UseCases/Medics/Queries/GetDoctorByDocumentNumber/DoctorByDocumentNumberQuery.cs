using Application.UseCases.Medics.Queries.GetDoctor;

namespace Application.UseCases.Medics.Queries.GetDoctorByDocumentNumber;

public record DoctorByDocumentNumberQuery(string DocumentNumber) : IRequest<DoctorDto>;