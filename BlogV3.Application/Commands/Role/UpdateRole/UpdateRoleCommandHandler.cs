using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Role.UpdateRole
{
    internal sealed class UpdateRoleCommandHandler(
        IRoleRepository _repository,
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
                return Result.Failure(Error.Notfound);
            }
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<RoleDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity!.Name == request.Name && entity.Id != request.Id)
            {
                return Result.Failure(Error.DifferentEntity);
            }
            entity!.Update(
                request.Name,
                request.UserId
            );
            _repository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<RoleDto>(entity));
        }

        #endregion Public Methods
    }
}