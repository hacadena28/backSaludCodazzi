using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentByID;

public class AppointmentByIdQueryHandler : IRequestHandler<AppointmentByIdQuery, AppointmentDto>
{
    private readonly IGenericRepository<Appointment> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentByIdQueryHandler(IGenericRepository<Appointment>? repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<AppointmentDto> Handle(AppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        var appointmentFilterById = await _appointmentServices.GetById(request.Id);
        var data = _mapper.Map<AppointmentDto>(appointmentFilterById);
        return data;
    }
}