namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetReschedule
{
    public class AppointmetRescheduleValidator : AbstractValidator<AppointmetRescheduleCommand>
    {
        public AppointmetRescheduleValidator()
        {
            RuleFor(_ => _.Id).NotNull();
            RuleFor(_ => _.NewDate).NotNull().When(_ => _.NewDate != null);
        }
    }
}