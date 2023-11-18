namespace Application.UseCases.Epses.Commands.EpsUpdate
{
    public class EpsChangeStateValidator : AbstractValidator<EpsChangeStateCommand>
    {
        public EpsChangeStateValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("El campo Valor no puede estar vacío.")
                .Must(_ => _ == null || _ is Guid).WithMessage("El campo Valor debe ser de tipo Guid.");
        }
    }
}