using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Services;

namespace Application.UseCases.Appointment.Commands.AppointmentCreate;

public class AppointmentCreateCommandHandler : IRequestHandler<AppointmentCreateCommand, EmptyAppointmentDto>
{
    private readonly AppointmentService _serviceAppointment;
    private readonly DoctorService _serviceDoctor;
    private readonly PatientService _servicePatient;
    private readonly IMapper _mapper;

    public AppointmentCreateCommandHandler(AppointmentService serviceAppointment, DoctorService serviceDoctor,PatientService servicePatient, IMapper mapper)
    {
        _serviceAppointment = serviceAppointment ?? throw new ArgumentNullException(nameof(serviceAppointment));
        _serviceDoctor = serviceDoctor ?? throw new ArgumentNullException(nameof(serviceDoctor));
        _servicePatient = servicePatient ?? throw new ArgumentNullException(nameof(servicePatient));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmptyAppointmentDto> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var patient = new Domain.Entities.Patient();
        var doctor = new Domain.Entities.Doctor();
        patient.Id = request.PatientId;
        doctor.Id = request.DoctorId;
        var existingPatient = await _servicePatient.GetById(patient);
        var existingDoctor = await _serviceDoctor.GetById(doctor);
        await _serviceAppointment.CreateAppointment(
            new Domain.Entities.Appointment(request.Date,request.State,request.Type,request.Description,existingPatient,existingDoctor)
        );
        return new EmptyAppointmentDto();
    }
}