namespace Application.UseCases.Medics.Queries.GetEpsNormal;

public record GetAllDoctorQuery : IRequest<IEnumerable<DoctorNormalDto>>;