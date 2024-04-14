using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArquitectureNet.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator() 
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no permite nulos");

            RuleFor(p => p.Apellido)
                .NotNull().WithMessage("{Apellido} no permite nulos");
        }
    }
}
