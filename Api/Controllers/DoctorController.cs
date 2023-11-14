using Api.Filters;
using Application.UseCases.Doctor.Commands.DoctorUpdate;
using Application.UseCases.Doctor.Queries.GetDoctor;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator) => _mediator = mediator;


    [HttpGet]
    [SwaggerResponseExample(400, typeof(ErrorResponse))]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(DoctorDto), StatusCodes.Status200OK)]
    public async Task<List<DoctorDto>> Get() => await _mediator.Send(new DoctorQuery());

    [HttpPut]
    public async Task<DoctorDto> Update(DoctorUpdateCommand command)
    {
        var updatedDoctor = await _mediator.Send(command);
        return updatedDoctor;
    }
}