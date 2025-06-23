using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Role.CreateRole
{
    internal sealed class CreateRoleCommandHandler(
        IRoleRepository _repository,
        IMapper _mappper,
        IValidator<CreateRoleCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreateRoleCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return Result.Failure<List<RoleDto>>(Error.Validation, validationResult.ToErrorList());
            }

            var entity = BlogV3.Domain.Entities.Role.Create(request.Name, request.UserId);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<RoleDto>(entity));
        }

        #endregion Public Methods
    }
}