using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;

namespace Domain.Tests;

public class RecordEpsTest
{
    private readonly IGenericRepository<Eps> _epsRepository;
    private readonly EpsService _service = default!;

    Eps _eps;
    private string _epsName = "Cosalud";
    private EpsState _state = EpsState.Active;

    public RecordEpsTest()
    {
        _epsRepository = Substitute.For<IGenericRepository<Eps>>();
        _service = new EpsService(_epsRepository);
    }

    [Fact]
    public async Task RecordEpsWhenEpsIsValid()
    {
        _eps = new EpsBuilder().WithName(_epsName).WithState(_state).Build();
        Console.WriteLine(_eps.Id);
        _epsRepository.AddAsync(Arg.Any<Eps>()).Returns(_eps); // mokear eps
        await _service.CreateEps(_eps);
        await _epsRepository.Received().AddAsync(Arg.Any<Eps>());
        //Validar que se llamo Al AddSunc por lo menos una vez
        Assert.NotNull(_eps.Id);
        Assert.IsType<Guid>(_eps.Id);
    }

    // [Fact]
    // public async Task RecordEpsWhenEpsIsNotValid()
    // {
    //     _eps = new EpsBuilder().WithName("").WithState(_state).Build();
    //     _epsRepository.AddAsync(Arg.Any<Eps>()).Returns(_eps); // mokear eps
    //     var result = await _service.RecordEpsAsync(_eps);
    //     await _epsRepository.Received().AddAsync(Arg.Any<Eps>());
    //     Assert.Equal(_eps, result);
    //     Assert.IsType<Guid>(result.GetId());
    // }
}