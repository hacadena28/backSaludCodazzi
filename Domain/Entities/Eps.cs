using Domain.Enums;

namespace Domain.Entities;

public class Eps : EntityBase<Guid>
{
    public string Name { get; set; }
    public EpsState State { get; set; }

    public Eps(string name, EpsState state = EpsState.Active)
    {
        Name = name;
        State = state;
    }

    public void EnableState()
    {
        State = EpsState.Active;
    }

    public void DisableState()
    {
        State = EpsState.Inactive;
    }
}