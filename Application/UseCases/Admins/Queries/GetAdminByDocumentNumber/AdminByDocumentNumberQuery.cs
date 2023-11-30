using Application.UseCases.Admins.Queries.GetAdmin;
using Application.UseCases.Medics.Queries.GetDoctor;

namespace Application.UseCases.Admins.Queries.GetAdminByDocumentNumber;

public record AdminByDocumentNumberQuery(string DocumentNumber) : IRequest<AdminDto>;