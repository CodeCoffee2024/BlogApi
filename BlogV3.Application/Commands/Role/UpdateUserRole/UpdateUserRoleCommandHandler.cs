using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Commands.Role.UpdateUserRole
{
    internal sealed class UpdateUserRoleCommandHandler(
        IRoleRepository _repository,
        IUserRepository _userRepository,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdateUserRoleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            foreach (Guid roleId in request.RoleIds)
            {
                if (!await _repository.ExistsAsync(roleId))
                {
                    return Result.Failure(Error.Notfound("Role"));
                }
            }

            var user = await _userRepository.GetByIdAsync(request.UserId);

            user!.UserRoles.Clear();
            foreach (Guid roleId in request.RoleIds)
            {
                var role = await _repository.GetByIdAsync(roleId);
                user!.AssignRole(role!);
            }

            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }

        #endregion Public Methods
    }
}