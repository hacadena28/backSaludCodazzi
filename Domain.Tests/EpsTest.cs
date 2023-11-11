using Domain.Entities;
using Domain.Enums;

namespace Domain.Tests;

public class EpsTest
{
    Eps _eps;
    private string _name = "Cosalud";
    private EpsState _state = EpsState.Active;

    [Fact]
    public void ChangeEnableState()
    {
        _eps = new EpsBuilder()
            .WithName(_name)
            .WithState(_state)
            .Build();

        _eps.EnableState();

        Assert.Equal(EpsState.Active, _eps.State);
    }

    [Fact]
    public void ChangeDisabledState()
    {
        _eps = new EpsBuilder()
            .WithName(_name)
            .WithState(_state)
            .Build();

        _eps.DisableState();

        Assert.Equal(EpsState.Inactive, _eps.State);
    }
}