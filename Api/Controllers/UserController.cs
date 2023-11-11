using Api.Examples.UserExamples;
using Api.Filters;
using Application.UseCases.User.Commands.UserDelete;
using Application.UseCases.User.Commands.UserUpdate;
using Application.UseCases.User.Queries.GetUser;
using Application.UseCases.Users.Commands.UserCreate;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    // [SwaggerRequestExample(typeof(UserCreateCommand), typeof(UserCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<UserDtoEmpty> Create(UserCreateCommand command) => await _mediator.Send(command);

    [HttpGet]
    [SwaggerRequestExample(typeof(UserQuery), typeof(GetUserQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<List<UserDto>> Get() => await _mediator.Send(new UserQuery());

    [HttpPut]
    public async Task<UserDto> Update(UserUpdateCommand command)
    {
        var updatedUser = await _mediator.Send(command);
        return updatedUser;
    }

    [HttpDelete("{id}")]
    public async Task<UserDtoEmpty> Delete(Guid id)
    {
        var deleteUser = await _mediator.Send(new UserDeleteCommand(id));
        return deleteUser;
    }
}