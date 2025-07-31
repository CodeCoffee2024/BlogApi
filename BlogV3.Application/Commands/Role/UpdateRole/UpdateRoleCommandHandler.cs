using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlogV3.Application.Commands.Role.UpdateRole
{
    internal sealed class UpdateRoleCommandHandler(
        IRoleRepository _repository,
        IPermissionRepository _permissionRepository,
        IMapper _mappper,
        IValidator<UpdateRoleCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdateRoleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.ExistsAsync(request.Id);
            if (!exists)
            {
                return Result.Failure(Error.Notfound("Role"));
            }
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Result.Failure<List<RoleDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = await _repository.GetByNameAsync(request.Name);
            if (entity != null && entity!.Name == request.Name && entity!.Id != request.Id)
            {
                validationResult.Errors.Add(new ValidationFailure("Name", Error.DifferentEntity.Description));
                return Result.Failure<List<RoleDto>>(Error.Validation, validationResult.ToErrorList());
            }
            entity = await _repository.GetByIdAsync(request.Id);
            entity!.Update(
                request.Name,
                request.UserId
            );
            var permissionsToRemove = entity.RolePermissions
                .Where(rp => !request.Permissions.Any(it => it == rp.Permission.Id))
                .ToList();

            foreach (var rp in permissionsToRemove)
            {
                entity.RolePermissions.Remove(rp);
            }

            foreach (Guid id in request.Permissions)
            {
                if (!entity.RolePermissions.Any(it => it.Permission.Id == id))
                {
                    var permission = await _permissionRepository.GetByIdAsync(id);
                    entity.AddPermission(permission!);
                }
            }
            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<RoleDto>(entity));
        }

        #endregion Public Methods
    }
}