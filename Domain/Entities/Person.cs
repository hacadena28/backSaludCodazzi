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
        Birthdate = (IsValidDateOfBirth(birthdate) ? birthdate : throw new CoreBusinessException("Fecha invalida"));
    }

    public Person()
    {
    }

    private bool IsValidDateOfBirth(DateTime dateOfBirth)
    {
        return dateOfBirth <= DateTime.Today;
    }

    public void Update(string? firstName, string? secondName, string? lastName,
        string? secondLastName, string? email, string? phone,
        string? address)
    {
        if (firstName != null && !FirstName.Equals(firstName) && firstName != "") FirstName = firstName;
        if (secondName != null && !SecondName.Equals(secondName) && secondName != "") SecondName = secondName;
        if (lastName != null && !LastName.Equals(lastName) && lastName != "") LastName = lastName;
        if (secondLastName != null && !SecondLastName.Equals(secondLastName) && secondLastName != "")
            SecondLastName = secondLastName;
        if (email != null && !Email.Equals(email) && email != "") Email = email;
        if (phone != null && !Phone.Equals(phone) && phone != "") Phone = phone;
        if (address != null && !Address.Equals(address) && address != "") Address = address;
    }
}