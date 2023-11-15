using Application.UseCases.Appointment.Queries.GetAppointment;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Appointment.Commands.AppointmentUpdate
{
    public class AppointmentUpdateCommandHandler : IRequestHandler<AppointmentUpdateCommand, AppointmentDto>
    {
        private readonly AppointmentService _appointmentService;
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;

        public AppointmentUpdateCommandHandler(AppointmentService appointmentService, DoctorService doctorService,
            IMapper mapper)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AppointmentDto> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Domain.Entities.Appointment();
            var doctor = new Domain.Entities.Doctor();
            appointment.Id = request.Id;
            doctor.Id = request.DoctorId;
            var existingAppointment = await _appointmentService.GetById(appointment);
            var existingDoctor = await _doctorService.GetById(doctor);
            if (existingAppointment == null)
            {
                throw new Exception("La Cita no se encontró o no existe.");
            }

            if (existingAppointment.Id == request.Id)
            {
                existingAppointment.Date = request.Date;
                existingAppointment.State = request.State;
                existingAppointment.Type = request.Type;
                existingAppointment.Description = request.Description;
                existingAppointment.Doctor = existingDoctor;

                await _appointmentService.UpdateAppointment(existingAppointment);

                var updatedAppointment = await _appointmentService.GetById(existingAppointment);

                return _mapper.Map<AppointmentDto>(updatedAppointment);
            }
            else
            {
                throw new Exception("Los id No Coinciden");
            }
        }
    }
}