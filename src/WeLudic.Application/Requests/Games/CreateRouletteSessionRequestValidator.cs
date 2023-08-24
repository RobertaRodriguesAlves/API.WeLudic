using FluentValidation;

namespace WeLudic.Application.Requests.Games;

public sealed class CreateRouletteSessionRequestValidator : AbstractValidator<CreateRouletteSessionRequest>
{
    public CreateRouletteSessionRequestValidator()
    {
        RuleFor(p => p.Options)
          .NotNull()
          .Must(p => p.Any())
          .WithMessage("Não é possível criar sem nenhuma opção");

        RuleFor(p => p.Options).Custom((collection, context) =>
        {
            if (collection.Count() < 5)
                context.AddFailure("Selecione no mínimo 5 opções");
            else if (collection.Count() > 12)
                context.AddFailure("Selecione no máximo 12 opções");
        });
    }
}