using Api.Examples.UserExamples;
using Api.Filters;
using Application.Common.Exceptions;
using Application.UseCases.Users.Commands.UserCreateDoctor;
using Application.UseCases.Users.Commands.UserUpdate;
using Application.UseCases.Users.Queries.GetUser;
using Application.UseCases.Users.Commands.UserCreatePatient;
using Application.UseCases.Users.Commands.UserDelete;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpPost("patient")]
    [SwaggerRequestExample(typeof(UserCreatePatientCommand), typeof(UserCreatePatientCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task CreateUserPatient(UserCreatePatientCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpPost("doctor")]
    [SwaggerRequestExample(typeof(UserCreateDoctorCommand), typeof(UserCreateDoctorCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task CreateUserDoctor(UserCreateDoctorCommand command)
    {
        await _mediator.Send(command);
    }

    [HttpGet]
    [SwaggerRequestExample(typeof(UserQuery), typeof(GetUserQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserCreateResponseExample))]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<List<UserDto>> Get() => await _mediator.Send(new UserQuery());


    [HttpPut("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task Update(UserUpdateCommand command, Guid id)
    {
        if (id != command.Id)
        {
            throw new ConflictException("The id of route no is the same of the command");
        }

        await _mediator.Send(command);
    }


    [HttpDelete("{id:guid}")]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task Delete(Guid id) => await _mediator.Send(new UserDeleteCommand(id));
}