using Application.UseCases.Admins.Queries.GetAdmin;

namespace Application.UseCases.Admins.Queries.GetAdminByID;

public record AdminByIdQuery(Guid Id) : IRequest<AdminDto>;