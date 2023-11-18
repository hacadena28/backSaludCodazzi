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

    public Person(
        string firstName, string secondName, string lastName, string secondLastName, TypeDocument documentType,
        string documentNumber, string email, string phone, string address, DateTime birthdate)
    {
        FirstName = firstName.Length >= 2 & firstName.Length <= 40
            ? firstName
            : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        SecondName = secondName.Length >= 2 & secondName.Length <= 40
            ? secondName
            : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        LastName = lastName.Length >= 2 & lastName.Length <= 40
            ? lastName
            : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        SecondLastName = secondLastName.Length >= 2 & secondLastName.Length <= 40
            ? secondLastName
            : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        DocumentType = documentType;
        DocumentNumber = int.TryParse(documentNumber, out _)
            ? documentNumber.Length >= 6 & documentNumber.Length <= 10
                ? firstName
                : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired)
            : throw new TheDataIsNotANumber(Messages.TheDataIsNotANumber);
        Email = IsValidEmail(email) ? email : throw new TheEmailIsNotValids(Messages.TheEmailIsNotValid);
        ;
        Phone = int.TryParse(phone, out _)
            ? phone.Length >= 8 & phone.Length <= 10
                ? phone
                : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired)
            : throw new TheDataIsNotANumber(Messages.TheDataIsNotANumber);
        Address = address.Length >= 2 & address.Length <= 40
            ? address
            : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        Birthdate = IsValidDateOfBirth(birthdate)
            ? birthdate
            : throw new TheDateIsNotValid(Messages.TheDateIsNotValid);
    }

    public Person()
    {
    }

    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        return Regex.IsMatch(email, emailPattern);
    }

    private bool IsValidDateOfBirth(DateTime dateOfBirth)
    {
        return dateOfBirth <= DateTime.Today;
    }
}