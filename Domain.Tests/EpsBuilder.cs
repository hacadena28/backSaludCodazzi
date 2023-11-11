using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class EpsBuilder
{
    private string Name;
    private EpsState State;
    private Guid Id;

    public EpsBuilder WithName(string name)
    {
        Name = name;
        return this;
    }


    public Eps Build()
    {
        return new Eps(Name, State);
    }


    public EpsBuilder WithState(EpsState state = EpsState.Active)
    {
        State = state;
        return this;
    }
}