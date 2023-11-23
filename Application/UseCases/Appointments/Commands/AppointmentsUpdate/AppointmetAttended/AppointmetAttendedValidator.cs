namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetAttended
{
    public class AppointmetAttendedValidator : AbstractValidator<AppointmetAttendedCommand>
    {
        public AppointmetAttendedValidator()
        {
            RuleFor(_ => _.Id).NotNull();
        }
    }
}