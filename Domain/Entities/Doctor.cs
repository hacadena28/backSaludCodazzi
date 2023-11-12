using Domain.Enums;

namespace Domain.Entities;

public class Doctor : Person
{
    public string Specialization { get; set; }

    public Doctor
    (
        string firstName,
        string secondName,
        string lastName,
        string secondLastName,
        TypeDocument documentType,
        string documentNumber,
        string email,
        string phone,
        string address,
        DateTime birthdate,
        string specialization
    ) : base(firstName, secondName, lastName, secondLastName, documentType, documentNumber, email, phone, address,
        birthdate)
    {
        Specialization = specialization;
    }

    public Doctor()
    {
    }
}