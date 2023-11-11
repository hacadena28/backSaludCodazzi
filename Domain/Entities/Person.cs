using Domain.Entities;
using Domain.Enums;

namespace Domain.Entities;

public abstract class Person : EntityBase<Guid>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public TypeDocument DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public string Email { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }

    public Person(string firstName, string secondName, string lastName, string secondLastName,
        TypeDocument documentType,
        string documentNumber, string email, long phone, string address, DateTime birthdate)
    {
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Email = email;
        Phone = phone;
        Address = address;
        Birthdate = birthdate;
    }

    public Person()
    {
    }

    public Guid GetId()
    {
        return Id;
    }

    public string GetFirstName()
    {
        return FirstName;
    }

    public string GetSecondName()
    {
        return SecondName;
    }

    public string GetLastName()
    {
        return LastName;
    }

    public string GetSecondLastName()
    {
        return SecondLastName;
    }

    public TypeDocument GetDocumentType()
    {
        return DocumentType;
    }

    public string GetDocumentNumber()
    {
        return DocumentNumber;
    }

    public string GetEmail()
    {
        return Email;
    }

    public long GetPhone()
    {
        return Phone;
    }

    public string GetAddress()
    {
        return Address;
    }

    public DateTime GetBirthdate()
    {
        return Birthdate;
    }
}