using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class PersonTest
{
    private Person _person;
    private string _identification = "1007824012";
    private string _password = "1007824012";
    private Role _rol = Role.Patient;
    private Role _rol2 = Role.Doctor;


    private string _firstName = "heli";
    private string _secondName = "Alberto";
    private string _lastName = "Cadena";
    private string _secondLastName = "Arenilla";
    private TypeDocument _documentType = TypeDocument.IdentificationCard;
    private string _documentNumber = "1007824012";
    private string _email = "Heli@gmail.com";
    private long _phone = 3206870778;
    private string _address = "calle 18D";
    private DateTime _birthdate = DateTime.Today;
}