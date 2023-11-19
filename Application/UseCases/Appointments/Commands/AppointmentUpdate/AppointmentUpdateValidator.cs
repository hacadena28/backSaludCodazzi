using Domain.Enums;
using NSubstitute;

namespace Application.UseCases.Appointments.Commands.AppointmentUpdate
{
    public class AppointmentUpdateValidator : AbstractValidator<AppointmentUpdateCommand>
    {
        public AppointmentUpdateValidator()
        {
            RuleFor(_ => _.Id).NotNull();
            RuleFor(_ => _.Date).NotNull().When(_ => _.Date != null);
            RuleFor(_ => _.State).NotNull().When(_ => _.State != null)
                .Must(state => Enum.IsDefined(typeof(AppointmentState), state));
        }
    }
}