using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class UserBuilder
{
    private string Password;
    private Role Role;
    private Guid PersonId;
    private Person Person;
    private Guid Id;

    public UserBuilder WithPassword(string password)
    {
        Password = password;
        return this;
    }

    public UserBuilder WithRole(Role role)
    {
        Role = role;
        return this;
    }

    public UserBuilder WithPersonId(Guid personId)
    {
        PersonId = personId;
        return this;
    }

    public UserBuilder WithPerson(Person person)
    {
        Person = person;
        return this;
    }

    public User Build()
    {
        return new User(Password, Role, Person);
    }
}