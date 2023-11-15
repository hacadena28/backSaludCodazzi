using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Enums;

namespace Application.UseCases.Appointment.Queries.GetAppointment;


public record AppointmentDto(Guid Id, DateTime Date, AppointmentState State,TypeAppointment Type,string Description, Guid PatientId,Guid DoctorId );