using System.Net;
using System.Net.Http.Json;
using Domain.Ports;
using Domain.Tests;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Eps.Commands.EpsCreate;
using Application.UseCases.Eps.Commands.EpsUpdate;
using Application.UseCases.User.Commands.UserUpdate;
using Application.UseCases.User.Queries.GetUser;
using Domain.Entities;
using Domain.Enums;
using Domain.Services;
using NSubstitute;

namespace Api.Tests;

public class UserApiTest
{
    Patient patient = new Patient("heli", "alberto", "Cadena", "Arenilla", TypeDocument.IdentificationCard,
        "1007824012", "prueba@gmail.com", 3206870778, "calle 20", new DateTime(2001, 04, 28));
    // [Fact]
    // public async Task GetSingleUserSuccess()
    // {
    //     await using var webApp = new ApiApp();
    //     var serviceCollection = webApp.GetServiceCollection();
    //     using var scope = serviceCollection.CreateScope();
    //     var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<User>>();
    //     await repository = AddAsync(new User("1007824012", "1007824012", Role.Patient));
    //     {
    //         
    //     }
    // }

    // [Fact]
    // public async Task GetSingleUserSuccess()
    // {
    //     await using var webApp = new ApiApp();
    //     var serviceCollection = webApp.GetServiceCollection();
    //     using var scope = serviceCollection.CreateScope();
    //     var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<User>>();
    //     await repository.AddAsync(new User("Cosalud24"));
    //     var client = webApp.CreateClient();
    //     var singleUser = await client.GetFromJsonAsync<List<UserDto>>($"/api/user");
    //     Assert.True(singleUser is List<UserDto>);
    //     Assert.NotNull(singleUser);
    //     Assert.NotEmpty(singleUser);
    // }
    //
    // [Fact]
    // public async Task PostUserSuccess()
    // {
    //     await using var webApp = new ApiApp();
    //     UserCreateCommand user = new("Cosalud");
    //     var userRepository = Substitute.For<IGenericRepository<User>>();
    //     userRepository.AddAsync(Arg.Any<User>()).Returns(callInfo => callInfo.Arg<User>());
    //     var userService = new UserService(userRepository);
    //     await userService.CreateUser(new User(user.Name, user.State));
    //     var client = webApp.CreateClient();
    //     var request = await client.PostAsJsonAsync("/api/user/", user);
    //     request.EnsureSuccessStatusCode();
    //
    //
    //     await userRepository.Received(1).AddAsync(Arg.Any<User>());
    // }
    //
    // [Theory]
    // [InlineData("", HttpStatusCode.BadRequest)]
    // [InlineData("Anticonstitucionalidadinconstitucionalid1", HttpStatusCode.BadRequest)]
    // [InlineData("Cosalud", HttpStatusCode.OK)]
    // public async Task CreateUserWithDifferentNameScenarios(string name, HttpStatusCode expectedStatusCode)
    // {
    //     await using var webApp = new ApiApp();
    //     UserCreateCommand user = new(name);
    //     var client = webApp.CreateClient();
    //     var request = await client.PostAsJsonAsync("/api/user/", user);
    //     Assert.Equal(expectedStatusCode, request.StatusCode);
    // }
    //
    //
    // [Theory]
    // [InlineData("", UserState.Inactive, HttpStatusCode.BadRequest)]
    // [InlineData("Anticonstitucionalidadinconstitucionalid1", UserState.Inactive, HttpStatusCode.BadRequest)]
    // [InlineData("Cosalud", UserState.Inactive, HttpStatusCode.OK)]
    // public async Task UpdateUserWithDifferentNameScenarios(string name, UserState state,
    //     HttpStatusCode expectedStatusCode)
    // {
    //     await using var webApp = new ApiApp();
    //     var serviceCollection = webApp.GetServiceCollection();
    //     using var scope = serviceCollection.CreateScope();
    //     var repository = scope.ServiceProvider.GetRequiredService<IGenericRepository<User>>();
    //     var client = webApp.CreateClient();
    //
    //     var user = new User("Cosalud24");
    //     await repository.AddAsync(user);
    //
    //     var updatedUser = new UserUpdateCommand(user.Id, name, state);
    //     var request = await client.PutAsJsonAsync($"/api/user/", updatedUser);
    //
    //     Assert.Equal(expectedStatusCode, request.StatusCode);
    // }
}