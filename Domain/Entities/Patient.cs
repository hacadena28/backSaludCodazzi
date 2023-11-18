using Domain.Enums;

namespace Domain.Entities;

public class Patient : Person
{
    public Guid EpsId { get; set; }
    public virtual Eps Eps { get; set; }

    public Patient
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
        Guid epsId
    ) : base(firstName, secondName, lastName, secondLastName, documentType, documentNumber, email, phone, address,
        birthdate)
    {
        EpsId = epsId;
    }

    public Patient()
    {
    }
}