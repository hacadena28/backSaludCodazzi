using System.ComponentModel.DataAnnotations.Schema;
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
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime Birthdate { get; set; }

    public Person(
        string firstName, string secondName, string lastName, string secondLastName, TypeDocument documentType,
        string documentNumber, string email, string phone, string address, DateTime birthdate)
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
}