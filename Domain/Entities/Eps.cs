using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Eps : EntityBase<Guid>
{
    public string Name { get; set; }
    public EpsState State { get; set; }

    public Eps
    (
        string name,
        EpsState state = EpsState.Active
    )
    {
        Name = name.Length >= 2 ? Name : throw new NumberOfCharactersRequired(Messages.NumberOfCharactersRequired);
        State = state;
    }


    public void ChangeState()
    {
        if (State == EpsState.Active)
            State = EpsState.Inactive;
        else State = EpsState.Active;
    }
}