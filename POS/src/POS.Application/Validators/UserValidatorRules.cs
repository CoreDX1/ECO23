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
            .WithMessage("La contraseña no puede estar vacia");
        RuleFor<string?>(x => x.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("El email no puede estar vacio");
        RuleFor(x => x.IdProvince).IsInEnum().WithMessage("El id de provincia no es valido");
    }
}
