using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class PatientBuilder
{
    private string FirstName;
    private string SecondName;
    private string LastName;
    private string SecondLastName;
    private TypeDocument DocumentType;
    private string DocumentNumber;
    private string Email;
    private string Phone;
    private string Address;
    private DateTime _birthdate;
    private Eps Eps;
    private Guid EpsId;

    public PatientBuilder WithFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }

    public PatientBuilder WithSecondName(string secondName)
    {
        SecondName = secondName;
        return this;
    }

    public PatientBuilder WithLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }

    public PatientBuilder WithSecondLastName(string secondLastName)
    {
        SecondLastName = secondLastName;
        return this;
    }

    public PatientBuilder WithDocumentType(TypeDocument documentType)
    {
        DocumentType = documentType;
        return this;
    }

    public PatientBuilder WithDocumentNumber(string documentNumber)
    {
        DocumentNumber = documentNumber;
        return this;
    }


    public PatientBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public PatientBuilder WithPhone(string phone)
    {
        Phone = phone;
        return this;
    }

    public PatientBuilder WithAddress(string address)
    {
        Address = address;
        return this;
    }

    public PatientBuilder WithBirthdate(DateTime birthdate)
    {
        _birthdate = birthdate;
        return this;
    }
    public PatientBuilder WithEps(Eps eps)
    {
        Eps = eps;
        return this;
    }


    public Patient Build()
    {
        return new Patient(FirstName, SecondName, LastName, SecondLastName, DocumentType, DocumentNumber, Email, Phone,
            Address, _birthdate, EpsId);
    }
}