using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointments.Commands.AppointmentsCreate;

public class AppointmentCreateCommandHandler : IRequestHandler<AppointmentCreateCommand>
{
    private readonly AppointmentService _serviceAppointment;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<Doctor> _doctorRepository;

    public AppointmentCreateCommandHandler(AppointmentService serviceAppointment,
        IGenericRepository<User> patientRepository, IGenericRepository<Doctor> doctorRepository)
    {
        _serviceAppointment = serviceAppointment ?? throw new ArgumentNullException(nameof(serviceAppointment));
        _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
        _userRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
    }

    public async Task<Unit> Handle(AppointmentCreateCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(x => x.Id == request.UserId, includeStringProperties: "Person")).FirstOrDefault();
        var doctor = await _doctorRepository.GetByIdAsync(request.DoctorId);

        if (doctor == null || user == null)
        {
            throw new NotFoundException(Domain.Messages.ResourceNotFoundException);
        }

        var appointment = new Appointment
        (
            request.AppointmentStartDate,
            request.Type,
            request.Description,
            user.Person.Id,
            request.DoctorId
        );

        await _serviceAppointment.Create(appointment);

        return Unit.Value;
    }
}