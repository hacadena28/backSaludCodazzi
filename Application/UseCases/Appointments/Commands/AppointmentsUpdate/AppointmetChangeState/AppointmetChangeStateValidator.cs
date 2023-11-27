using Domain.Enums;

namespace Application.UseCases.Appointments.Commands.AppointmentsUpdate.AppointmetChangeState
{
    public class AppointmetChangeStateValidator : AbstractValidator<AppointmetChangeStateCommand>
    {
        public AppointmetChangeStateValidator()
        {
            RuleFor(_ => _.Id).NotNull();
            RuleFor(_ => _.State).NotNull().NotEmpty();
            RuleFor(_ => _.NewDate).NotNull()
                .When(_ => _.State == AppointmentState.Rescheduled)
                .WithMessage("El campo NewDate es obligatorio cuando el estado es 'Rescheduled'.");
        }
    }
}