using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlogV3.Application.Commands.User.UpdateUser
{
    internal sealed class UpdateUserCommandHandler(
        IUserRepository _repository,
        IMapper _mappper,
        IValidator<UpdateUserCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<UpdateUserCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            var idByUsername = await _repository.GetByUsernameAsync(request.UserName);
            var idByEmail = await _repository.GetByEmailAsync(request.Email);
            if (await _repository.EmailExists(request.Email))
            {
                if (idByEmail!.Id != request.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Email", "Email already exists."));
                }
            }

            if (await _repository.UsernameExists(request.UserName))
            {
                if (idByUsername!.Id != request.Id)
                {
                    validationResult.Errors.Add(new ValidationFailure("Username", "Username already exists."));
                }
            }
            if (!validationResult.IsValid)
            {
                return Result.Failure<List<UserDto>>(Error.Validation, validationResult.ToErrorList());
            }
            var entity = await _repository.GetByIdAsync(request.Id);
            entity!.Update(request.UserName, request.Email, request.Password, request.FirstName, request.LastName, request.MiddleName, DateTime.Now, request.UserId);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<UserDto>(entity));
        }

        #endregion Public Methods
    }
}