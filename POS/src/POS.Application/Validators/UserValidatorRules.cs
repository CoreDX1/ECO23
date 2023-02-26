using FluentValidation;
using POS.Application.DTO.Request;
using POS.Utilities.Static;

namespace POS.Application.Validators;

public class UserValidatorRules : AbstractValidator<UserEcoRequestDto>
{
    public UserValidatorRules()
    {
        RuleFor<string?>(x => x.UserPassword)
            .Equal(x => x.ReplyPassword)
            .WithMessage("Las contraseñas no coinciden")
            .NotNull()
            .NotEmpty()
            .WithMessage("La contraseña no puede estar vacia");
        RuleFor<string?>(x => x.Email)
            .EmailAddress()
            .WithMessage("El email no es valido")
            .NotNull()
            .NotEmpty()
            .WithMessage("El email no puede estar vacio");
        ;
        RuleFor(x => x.IdProvince).IsInEnum().WithMessage("El id de provincia no es valido");
    }
}
