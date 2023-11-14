using Application.UseCases.Doctor.Queries.GetDoctor;
using Domain.Enums;
using Domain.Tests;
using MediatR;

namespace Application.UseCases.Doctor.Commands.DoctorUpdate
{
    public record DoctorUpdateCommand(Guid Id, string firstName, string secondName, string lastName,
        string secondLastName, TypeDocument documentType, string documentNumber, string email, string phone,
        string address, DateTime birthdate,string specialization) : IRequest<DoctorDto>;
}