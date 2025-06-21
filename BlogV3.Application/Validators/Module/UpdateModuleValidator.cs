using BlogV3.Application.Commands.Module.UpdateModule;
using FluentValidation;

namespace BlogV3.Application.Validators.Module
{
    public class UpdateModuleValidator : AbstractValidator<UpdateModuleCommand>
    {
        #region Public Constructors

        public UpdateModuleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);
        }

        #endregion Public Constructors
    }
}