using Domain.Enums;

namespace Application.UseCases.Eps.Commands.EpsDelete;

public class EpsDeleteValidator : AbstractValidator<EpsDeleteCommand>
{
    public EpsDeleteValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("El campo Valor no puede estar vacío.")
            .Must(value => value == null || value is Guid).WithMessage("El campo Valor debe ser de tipo Guid.");
    }
}