using Domain.Ports;

namespace Application.UseCases.Appointment.Queries.GetAppointment;

public class AppointmentQueryHandler : IRequestHandler<AppointmentQuery, List<AppointmentDto>>
{
    private readonly IGenericRepository<Domain.Entities.Appointment> _repository;
    private readonly IMapper _mapper;

    public AppointmentQueryHandler(IGenericRepository<Domain.Entities.Appointment>? repository, IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    public async Task<List<AppointmentDto>> Handle(AppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = (await _repository.GetAsync()).ToList();
        return _mapper.Map<List<AppointmentDto>>(appointment);
    }
}