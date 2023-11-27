using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public class AppointmentCreateCommandHandler : IRequestHandler<AppointmentCreateCommand>
{
    private readonly AppointmentService _serviceAppointment;
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly IGenericRepository<Doctor> _doctorRepository;

    public AppointmentCreateCommandHandler(AppointmentService serviceAppointment,
        IGenericRepository<Patient> patientRepository, IGenericRepository<Doctor> doctorRepository)
    {
        _serviceAppointment = serviceAppointment ?? throw new ArgumentNullException(nameof(serviceAppointment));
        _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
    }

    public async Task<Unit> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdAsync(request.PatientId);
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor == null || patient == null)
        {
            throw new CoreBusinessException("La etidad patient o doctor no existe");
        }

        var appointment = new Appointment
        (
            request.AppointmentStartDate,
            request.Type,
            request.Description,
            request.PatientId,
            request.DoctorId
        );

        await _serviceAppointment.Create(appointment);

        return Unit.Value;
    }
}