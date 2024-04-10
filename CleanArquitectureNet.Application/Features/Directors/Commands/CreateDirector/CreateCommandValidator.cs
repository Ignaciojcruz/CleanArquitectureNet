using FluentValidation;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{Apellido} no puede ser nulo");
        }
    }
}
