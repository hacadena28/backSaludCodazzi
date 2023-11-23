using Domain.Enums;

namespace Domain.Entities;

public class Eps : EntityBase<Guid>
{
    public string Name { get; set; }
    public EpsState State { get; set; }

    public Eps(string name)
    {
        Name = name;
        State = EpsState.Active;
    }

    public Eps()
    {
    }


    public void Update(string name)
    {
        if (Name.Equals(name) is not true) Name = name;
    }

    private void ChangeState(EpsState newState)
    {
        if (newState != State) State = newState;
    }
}