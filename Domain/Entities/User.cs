using Domain.Enums;

namespace Domain.Entities;

public class User : EntityBase<Guid>
{
    public string Password { get; set; }
    public Role Role { get; set; }

    public Guid PersonId { get; set; }
    public virtual Person Person { get; set; }

    public User()
    {
    }

    public User(string password, Role role, Person person)
    {
        Password = password;
        Role = role;
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