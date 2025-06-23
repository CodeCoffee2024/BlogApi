using BlogV3.Application.Commands.Permission.UpdatePermission;
using FluentValidation;

namespace BlogV3.Application.Validators.Permission
{
    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionCommand>
    {
        #region Public Constructors

        public UpdatePermissionValidator()
        {
            RuleFor(x => x.ModuleId)
                .NotEmpty().WithMessage("Module is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100);
        }

        #endregion Public Constructors
    }
}