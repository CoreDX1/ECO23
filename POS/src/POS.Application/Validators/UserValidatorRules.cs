using FluentValidation;
using POS.Application.DTO.Request;
using POS.Infrastructure.Persistence.Interfaces;

namespace POS.Application.Validators;

public class UserValidatorRules : AbstractValidator<UserEcoRequestDto>
{
    public UserValidatorRules(IUnitOfWork unitOfWork)
    {
        RuleFor<string?>(x => x.UserPassword)
            .Equal(x => x.ReplyPassword)
            .WithMessage("Las contraseñas no coinciden")
            .NotNull()
            .NotEmpty()
            .WithMessage("La contraseña no puede estar vacia")
            .MinimumLength(6)
            .WithMessage("La contraseña debe tener al mas 6 caracteres")
            .MaximumLength(10)
            .WithMessage("La contraseña menor a 10 caracteres");
        RuleFor<string?>(x => x.Email)
            .EmailAddress()
            .WithMessage("El correo no es válido")
            .NotNull()
            .NotEmpty()
            .WithMessage("El email no puede estar vacio");
        RuleFor(x => x.IdProvince).IsInEnum().WithMessage("La provincia no es válida");
    }
}
