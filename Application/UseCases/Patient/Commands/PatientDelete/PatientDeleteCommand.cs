using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.Patient.Commands.PatientDelete
{
    public record PatientDeleteCommand(Guid Id):IRequest<PatientDtoEmpty> ;
}