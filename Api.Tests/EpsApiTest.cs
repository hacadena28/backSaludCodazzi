using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Application.UseCases.Eps.Commands.EpsCreate;
using Application.UseCases.Eps.Commands.EpsUpdate;
using Application.UseCases.Eps.Queries.GetEps;
using Domain.Entities;
using Domain.Enums;
using Domain.Ports;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace Api.Tests;

public class EpsApiTest
{
    [Fact]
    public async Task GetSingleEpsSuccess()
    {
        await using var webApp = new ApiApp();
        var serviceCollection = webApp.GetServiceCollection();
        using var scope = serviceCollection.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Eps>>();
        await repository.AddAsync(new Eps("Cosalud24"));
        var client = webApp.CreateClient();
        var singleEps = await client.GetFromJsonAsync<List<EpsDto>>($"/api/eps");
        Assert.True(singleEps is List<EpsDto>);
        Assert.NotNull(singleEps);
        Assert.NotEmpty(singleEps);
    }

    [Fact]
    public async Task PostEpsSuccess()
    {
        await using var webApp = new ApiApp();
        EpsCreateCommand eps = new("Cosalud");
        var epsRepository = Substitute.For<IGenericRepository<Eps>>();
        epsRepository.AddAsync(Arg.Any<Eps>()).Returns(callInfo => callInfo.Arg<Eps>());
        var epsService = new EpsService(epsRepository);
        await epsService.CreateEps(new Eps(eps.Name, eps.State));
        var client = webApp.CreateClient();
        var request = await client.PostAsJsonAsync("/api/eps/", eps);
        request.EnsureSuccessStatusCode();


        await epsRepository.Received(1).AddAsync(Arg.Any<Eps>());
    }

    [Theory]
    [InlineData("", HttpStatusCode.BadRequest)]
    [InlineData("Anticonstitucionalidadinconstitucionalid1", HttpStatusCode.BadRequest)]
    [InlineData("Cosalud", HttpStatusCode.OK)]
    public async Task CreateEpsWithDifferentNameScenarios(string name, HttpStatusCode expectedStatusCode)
    {
        await using var webApp = new ApiApp();
        EpsCreateCommand eps = new(name);
        var client = webApp.CreateClient();
        var request = await client.PostAsJsonAsync("/api/eps/", eps);
        Assert.Equal(expectedStatusCode, request.StatusCode);
    }


    [Theory]
    [InlineData("", EpsState.Inactive, HttpStatusCode.BadRequest)]
    [InlineData("Anticonstitucionalidadinconstitucionalid1", EpsState.Inactive, HttpStatusCode.BadRequest)]
    [InlineData("Cosalud", EpsState.Inactive, HttpStatusCode.OK)]
    public async Task UpdateEpsWithDifferentNameScenarios(string name, EpsState state,
        HttpStatusCode expectedStatusCode)
    {
        await using var webApp = new ApiApp();
        var serviceCollection = webApp.GetServiceCollection();
        using var scope = serviceCollection.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Eps>>();
        var client = webApp.CreateClient();

        var eps = new Eps("Cosalud24");
        await repository.AddAsync(eps);

        var updatedEps = new EpsUpdateCommand(eps.Id, name, state);
        var request = await client.PutAsJsonAsync($"/api/eps/", updatedEps);

        Assert.Equal(expectedStatusCode, request.StatusCode);
    }

    [Fact]
    public async Task DeleteEpsSuccess()
    {
        await using var webApp = new ApiApp();
        EpsCreateCommand epsCreateCommand = new("Cosalud");
        var epsRepository = Substitute.For<IGenericRepository<Eps>>();
        epsRepository.AddAsync(Arg.Any<Eps>()).Returns(callInfo => callInfo.Arg<Eps>());
        epsRepository.DeleteAsync(Arg.Any<Eps>()).Returns(callInfo => Task.CompletedTask);
        var epsService = new EpsService(epsRepository);

        Eps eps = new Eps(epsCreateCommand.Name, epsCreateCommand.State);
        await epsService.CreateEps(eps);
        var client = webApp.CreateClient();
        var request = await client.PostAsJsonAsync("/api/eps/", eps);
        await epsRepository.Received(1).AddAsync(Arg.Any<Eps>());
        var request2 = await client.DeleteAsync($"/api/eps/{eps.Id}");

        request.EnsureSuccessStatusCode();
        request2.EnsureSuccessStatusCode();
        // await epsRepository.Received(1).DeleteAsync(Arg.Any<Eps>());
    }
}