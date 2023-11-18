using Domain.Enums;
using Domain.Exceptions;

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
        if (password.Length < 8)
        {
            throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        }
        Password = password;
        Role = role;
        Person = person;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }
}