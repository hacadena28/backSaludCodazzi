using Domain.Enums;

namespace Application.UseCases.Eps.Commands.EpsUpdate
{
    public class EpsUpdateValidator : AbstractValidator<EpsUpdateCommand>
    {
        public EpsUpdateValidator()
        {
            RuleFor(_ => _.EpsName).NotNull().NotEmpty().MinimumLength(1).MaximumLength(40);
            RuleFor(_ => _.State).NotNull().Equal(EpsState.Active|EpsState.Inactive);
        }
    }
}


