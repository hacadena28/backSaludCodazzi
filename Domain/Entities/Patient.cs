using Domain.Entities;
using Domain.Enums;

namespace Domain.Entities;

public class Patient : Person
{
    public Patient
    (
        string firstName,
        string secondName,
        string lastName,
        string secondLastName,
        TypeDocument documentType,
        string documentNumber,
        string email,
        long phone,
        string address,
        DateTime birthdate
    ) : base(firstName, secondName, lastName, secondLastName, documentType, documentNumber, email, phone, address, birthdate)
    {
    }

    public Patient()
    {
    }
}