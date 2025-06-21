using BlogV3.Application.Commands.Module.CreateModule;
using BlogV3.Domain.Interfaces;
using FluentValidation;

namespace BlogV3.Application.Validators.Module
{
    public class CreateModuleValidator : AbstractValidator<CreateModuleCommand>
    {
        #region Public Constructors

        public CreateModuleValidator(IModuleRepository moduleRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Module name is required.")
                .MaximumLength(100)
                .MustAsync(async (name, cancellation) =>
                    !(await moduleRepository.ExistsByNameAsync(name)))
                .WithMessage("Module name already exist.");
        }

        #endregion Public Constructors
    }
}