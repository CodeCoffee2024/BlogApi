using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Application.Interfaces.Common;
using BlogV3.Common.Entities;
using BlogV3.Common.Helpers;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace BlogV3.Application.Commands.Post.CreatePost
{
    internal sealed class CreatePostCommandHandler(
        IPostRepository _repository,
        IFileService _fileService,
        ITagRepository _tagRepository,
        IMapper _mappper,
        IValidator<CreatePostCommand> _validator,
        IUnitOfWork _unitOfWork
    ) : IRequestHandler<CreatePostCommand, Result>
    {
        #region Public Methods

        public async Task<Result> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return Result.Failure<List<PostDto>>(Error.Validation, validationResult.ToErrorList());
            }
            string imgPath = await _fileService.UploadImage(request.Img);
            var entity = BlogV3.Domain.Entities.Post.Create(
                request.CategoryId,
                Status.Active.GetDescription()!,
                request.Title,
                request.Description,
                DateTime.Now,
                request.UserId,
                imgPath
            );
            await _repository.AddAsync(entity);
            foreach (string tag in request.Tags)
            {
                var tagEntity = BlogV3.Domain.Entities.Tag.Create(entity.Id!.Value, tag);
                await _tagRepository.AddAsync(tagEntity);
            }
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(_mappper.Map<PostDto>(entity));
        }

        #endregion Public Methods
    }
}