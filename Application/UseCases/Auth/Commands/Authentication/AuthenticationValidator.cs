namespace Application.UseCases.Auth.Commands.Authentication;

public class AuthenticationValidator : AbstractValidator<AuthenticationCommand>
{
    public AuthenticationValidator()
    {
        RuleFor(_ => _.DocumentNumber).NotNull().MinimumLength(6).MaximumLength(10);
        RuleFor(_ => _.Password).NotNull().NotEmpty().MinimumLength(8).MaximumLength(50);
    }
}