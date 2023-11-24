using Application.UseCases.Medics.Queries.GetDoctor;

namespace Application.UseCases.Medics.Queries.GetDoctorByID;

public record DoctorByIdQuery(Guid Id) : IRequest<DoctorDto>;