namespace Application.UseCases.Users.Commands.UserDelete;

public class UserDeleteValidator : AbstractValidator<UserDeleteCommand>
{
    public UserDeleteValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().WithMessage("El campo Valor no puede estar vacío.")
            .Must(value => value == null || value is Guid).WithMessage("El campo Valor debe ser de tipo Guid.");
    }
}