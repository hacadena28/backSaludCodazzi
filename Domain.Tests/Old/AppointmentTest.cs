// using Domain.Entities;
// using Domain.Enums;
// using Domain.Exceptions;
//
// namespace Domain.Tests;
//
// public class AppointmentTest
// {
//     Appointment _appointment; 
//     
//     public AppointmentTest()
//     {
//         _appointment = new Appointment(DateTime.Now.AddDays(-1));
//         
//     }
//     
//     [Fact]
//     public void CancelAppointment_StateShouldBeCancelled()
//     {
//         _appointment = new Appointment(DateTime.Now.AddDays(-1));
//         _appointment.Cancel();
//         Assert.Equal(AppointmentState.Cancelled, _appointment.State);
//     }
//
//     [Fact]
//     public void CancelAppointment_WhenStartDateIsCorrect()
//     {
//         _appointment = new Appointment(DateTime.Now.AddDays(-1));
//         _appointment.Cancel();
//         var timeSpan = DateTime.Now - _appointment.StartDate;
//         Assert.True(timeSpan.Days >= 1);
//         Assert.Equal(AppointmentState.Cancelled, _appointment.State);
//     }
//     
//     [Fact]
//     public void CancelAppointment_WhenStartDateIsMinorToOneDay()
//     {
//         try
//         {
//             _appointment = new Appointment(DateTime.Now);
//             _appointment.Cancel();
//             Assert.Fail("Aqui debe lanzarce la excepcion porque se configuro una fecha erronea");
//         }
//         catch ( CoreBusinessException e )
//         {
//             Assert.True(e is IncorrectAppointmentDateException);
//             Assert.Equal("La fecha debe ser mayor a un dia", e.Message);
//         }
//     }
// }
//
//
//
