using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Domain.Enums;
using Domain.Exceptions;

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
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }

    protected Person(
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
    )
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

    private bool IsValidDateOfBirth(DateTime dateOfBirth)
    {
        return dateOfBirth <= DateTime.Today;
    }
}