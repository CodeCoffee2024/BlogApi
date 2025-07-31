using BlogV3.Application.Commands.Role.CreateRole;
using BlogV3.Domain.Interfaces;
using FluentValidation;

namespace BlogV3.Application.Validators.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        #region Public Constructors

        public CreateRoleValidator(IRoleRepository roleRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100)
                .MustAsync(async (name, cancellation) =>
                    !(await roleRepository.ExistsByNameAsync(name)))
                .WithMessage("Name already exist.");
            RuleFor(x => x.Permissions)
                .NotEmpty().WithMessage("Atleast 1 permission is required.");
        }

        #endregion Public Constructors
    }
}