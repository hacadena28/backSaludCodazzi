using Domain.Enums;

namespace Domain.Entities;

public class Admin : Person
{
    public Admin
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
        DateTime birthdate
    ) : base(firstName, secondName, lastName, secondLastName, documentType, documentNumber, email, phone, address,
        birthdate)
    {
    }

    public Admin()
    {
    }

    public void Update(string? firstName, string? secondName, string? lastName,
        string? secondLastName, string? email, string? phone,
        string? address)
    {
        base.Update(firstName, secondName, lastName, secondLastName, email, phone, address);
    }
}