using Application.UseCases.Appointments.Queries.GetAppointments;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Queries.GetAppointmentsForDoctorByDay;

public class
    AppointmentsForDoctorByDayQueryHandler : IRequestHandler<AppointmentsForDoctorByDayQuery, List<AppointmentNamesDto>>
{
    private readonly IGenericRepository<Appointment> _repository;
    private readonly IGenericRepository<User> _userRepository;
    private readonly AppointmentService _appointmentServices;
    private readonly IMapper _mapper;

    public AppointmentsForDoctorByDayQueryHandler(IGenericRepository<Appointment>? repository,
        AppointmentService appointmentServices,
        IMapper mapper, IGenericRepository<User> userRepository) =>
        (_repository, _appointmentServices, _mapper, _userRepository) = (repository, appointmentServices, mapper, userRepository);

    public async Task<List<AppointmentNamesDto>> Handle(AppointmentsForDoctorByDayQuery request,
        CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(x => x.Id == request.DoctorId, includeStringProperties: "Person"))
            .FirstOrDefault();
        
        var appointmentFilterByPatientId =
            await _appointmentServices.GetAppointmentsForDoctorByDay(user.Person.Id, request.Date);
        var data = _mapper.Map<List<AppointmentNamesDto>>(appointmentFilterByPatientId);

        return data;
    }
}