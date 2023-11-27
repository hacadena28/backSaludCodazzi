using Application.Common.Helpers.Pagination;
using Application.UseCases.Appointments.Queries.GetAppointmentByPatientId;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByMonth;

public class
    AppointmentsForDoctorByMonthQueryHandler : IRequestHandler<AppointmentsForDoctorByMonthQuery, List<AppointmentDto>>
{
    private readonly IGenericRepository<Appointment> _repository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentsForDoctorByMonthQueryHandler(IGenericRepository<Appointment>? repository,
        AppointmentService appointmentServices,
        IMapper mapper) =>
        (_repository, _appointmentServices, _mapper) = (repository, appointmentServices, mapper);

    public async Task<List<AppointmentDto>> Handle(AppointmentsForDoctorByMonthQuery request,
        CancellationToken cancellationToken)
    {
        var appointmentFilterByPatientId =
            await _appointmentServices.GetAppointmentsForDoctorByMonth(request.DoctorId, request.Year,
                request.Month);
        var data = _mapper.Map<List<AppointmentDto>>(appointmentFilterByPatientId);

        return data;
    }
}