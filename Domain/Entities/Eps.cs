using Domain.Enums;

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
        Name = name;
        State = state;
    }

    public void ChangeState()
    {
        if (State == EpsState.Active)
            State = EpsState.Inactive;
        else if (State == EpsState.Inactive)
            State = EpsState.Active;
    }
}