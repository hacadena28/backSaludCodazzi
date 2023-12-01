using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByDay;

public class
    AppointmentsForDoctorByDayQueryHandler : IRequestHandler<AppointmentsForDoctorByDayQuery, List<AppointmentDto>>
{
    private readonly IGenericRepository<Appointment> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentsForDoctorByDayQueryHandler(IGenericRepository<Appointment>? repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<List<AppointmentDto>> Handle(AppointmentsForDoctorByDayQuery request,
        CancellationToken cancellationToken)
    {
        var appointmentFilterByPatientId =
            await _appointmentServices.GetAppointmentsForDoctorByDay(request.DoctorId, request.Date);
        var data = _mapper.Map<List<AppointmentDto>>(appointmentFilterByPatientId);

        return data;
    }
}