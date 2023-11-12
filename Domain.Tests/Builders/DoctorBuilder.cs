using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class DoctorBuilder
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
    private DateTime Birthdate;
    private string Specialization;

    public DoctorBuilder WithFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }

    public DoctorBuilder WithSecondName(string secondName)
    {
        SecondName = secondName;
        return this;
    }

    public DoctorBuilder WithLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }

    public DoctorBuilder WithSecondLastName(string secondLastName)
    {
        SecondLastName = secondLastName;
        return this;
    }

    public DoctorBuilder WithDocumentType(TypeDocument documentType)
    {
        DocumentType = documentType;
        return this;
    }

    public DoctorBuilder WithDocumentNumber(string documentNumber)
    {
        DocumentNumber = documentNumber;
        return this;
    }


    public DoctorBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public DoctorBuilder WithPhone(string phone)
    {
        Phone = phone;
        return this;
    }

    public DoctorBuilder WithAddress(string address)
    {
        Address = address;
        return this;
    }

    public DoctorBuilder WithBirthdate(DateTime birthdate)
    {
        Birthdate = birthdate;
        return this;
    }
    public DoctorBuilder WithSpecialization(string specialization)
    {
        Specialization = specialization;
        return this;
    }


    public Doctor Build()
    {
        return new Doctor(FirstName, SecondName, LastName, SecondLastName, DocumentType, DocumentNumber, Email, Phone,
            Address, Birthdate,Specialization);
    }
}