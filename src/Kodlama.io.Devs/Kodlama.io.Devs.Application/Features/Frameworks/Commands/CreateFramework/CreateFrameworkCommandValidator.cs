using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommandValidator : AbstractValidator<CreateFrameworkCommand>
    {
        public CreateFrameworkCommandValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).NotEmpty(); ;
            RuleFor(x => x.LanguageId).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
