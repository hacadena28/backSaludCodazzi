namespace Application.UseCases.Epses.Commands.EpsUpdate
{
    public class EpsUpdateValidator : AbstractValidator<EpsUpdateCommand>
    {
        public EpsUpdateValidator()
        {
            RuleFor(_ => _.Id).NotEmpty().WithMessage("El campo Valor no puede estar vacío.")
                .Must(_ => _ == null || _ is Guid).WithMessage("El campo Valor debe ser de tipo Guid.");
            RuleFor(_ => _.newName).NotNull().NotEmpty().MinimumLength(2).MaximumLength(40);
        }
    }
}