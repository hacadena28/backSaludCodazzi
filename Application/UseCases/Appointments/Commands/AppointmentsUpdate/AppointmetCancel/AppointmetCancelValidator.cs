namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetCancel
{
    public class AppointmetCancelValidator : AbstractValidator<AppointmetCancelCommand>
    {
        public AppointmetCancelValidator()
        {
            RuleFor(_ => _.Id).NotNull();
        }
    }
}