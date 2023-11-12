using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Appointment2
{
    private const int MinimumNumberDayToCancelled = 1;

    public AppointmentState State { get; private set; }
    public DateTime StartDate { get; private set; }

    public Appointment2(DateTime startDate)
    {
        StartDate = startDate;
    }

    public void Cancel()
    {
        State = (DateTime.Now - StartDate).Days >= MinimumNumberDayToCancelled
            ? AppointmentState.Cancelled
            : throw new IncorrectAppointmentDateException(Messages.IncorrectAppointmentDateException);
    }
}