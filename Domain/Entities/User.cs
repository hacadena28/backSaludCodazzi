using Domain.Enums;

namespace Domain.Entities;

public class User : EntityBase<Guid>
{
    public string Identification { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

    public Guid PersonId { get; set; }
    public Person Person { get; set; }

    public User()
    {
    }

    public User(string identification, string password, Role role, Guid personId, Person person)
    {
        Identification = identification;
        Password = password;
        Role = role;
        PersonId = personId;
        Person = person;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public string RecoveryPassword()
    {
        return Password;
    }
}