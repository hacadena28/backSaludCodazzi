using Domain.Enums;

namespace Application.UseCases.Eps.Commands.EpsCreate;
    public class EpsCreateValidator : AbstractValidator<EpsCreateCommand>
    {
        public EpsCreateValidator()
        {
            RuleFor(_ => _.Name).NotNull().NotEmpty().MinimumLength(1).MaximumLength(40);
            RuleFor(_ => _.State).NotNull().Must(state => Enum.IsDefined(typeof(EpsState), state));
        }
    }