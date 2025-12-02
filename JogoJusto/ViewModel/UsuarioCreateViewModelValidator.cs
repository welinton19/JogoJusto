using FluentValidation;

namespace JogoJusto.ViewModel;

public class UsuarioCreateViewModelValidator : AbstractValidator<UsuarioCreateViewModel>
{
    public UsuarioCreateViewModelValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O email é obrigatório.")
            .EmailAddress().WithMessage("O email fornecido não é válido.");
        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(8).WithMessage("A senha deve ter pelo menos 6 caracteres.");
        RuleFor(u => u.Tipo)
            .NotEmpty().WithMessage("O tipo de usuário é obrigatório.");
    }
}
