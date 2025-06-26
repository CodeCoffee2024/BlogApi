using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Common.Entities;
using BlogV3.Common.Helpers;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BlogV3.Application.Commands.Auth.Register
{
    internal sealed class RegisterCommandHandler(
        IUserRepository _repository,
        IPasswordHasherService _passwordHasherService,
        IMapper _mappper,
        IValidator<RegisterCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<RegisterCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (await _repository.EmailExists(request.Email))
            {
                validationResult.Errors.Add(new ValidationFailure("Email", "Email already exists."));
            }
            if (await _repository.UsernameExists(request.Email))
            {
                validationResult.Errors.Add(new ValidationFailure("Username", "Username already exists."));
            }

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<UserDto>>(Error.Validation, validationResult.ToErrorList());
            }
            var entity = BlogV3.Domain.Entities.User.Register(
                request.UserName,
                request.Email,
                _passwordHasherService.HashPassword(request.Password),
                Status.ForVerification.GetDescription()!,
                request.FirstName,
                request.LastName,
                request.MiddleName
            );
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<UserDto>(entity));
        }

        #endregion Public Methods
    }
}