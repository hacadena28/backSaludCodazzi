// using Domain.Entities;
// using Domain.Enums;
//
// namespace Domain.Tests;
//
// public class AppointmentBuilder
// {
//     private DateTime Date;
//     private AppointmentState State;
//     private TypeAppointment Type;
//     private string Description;
//     private Patient Patient;
//     private Doctor Doctor;
//
//     public AppointmentBuilder WithDate(DateTime date)
//     {
//         Date = date;
//         return this;
//     }
//
//     public AppointmentBuilder WithState(AppointmentState state)
//     {
//         State = state;
//         return this;
//     }
//
//     public AppointmentBuilder WithType(TypeAppointment type)
//     {
//         Type = type;
//         return this;
//     }
//
//     public AppointmentBuilder WithDescription(string description)
//     {
//         Description = description;
//         return this;
//     }
//
//     public AppointmentBuilder WithPatient(Patient patient)
//     {
//         Patient = patient;
//         return this;
//     }
//
//     public AppointmentBuilder WithDoctor(Doctor doctor)
//     {
//         Doctor = doctor;
//         return this;
//     }
//
//
//     public Appointment Build()
//     {
//         return new Appointment
//         (
//             Date,
//             State,
//             Type,
//             Description,
//             Patient,
//             Doctor
//         );
//     }
// }