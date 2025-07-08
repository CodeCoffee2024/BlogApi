using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Post.GetOnePost
{
    public class GetOnePostQueryHandler(IPostRepository _repository, IMapper _mapper) : IRequestHandler<GetOnePostQuery, Result<PostDto>>
    {
        #region Public Methods

        public async Task<Result<PostDto>> Handle(GetOnePostQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<PostDto>(Error.Notfound("Post"));
            }
            var mappedResult = _mapper.Map<PostDto>(result);
            return Result.Success(mappedResult);
        }

        #endregion Public Methods
    }
}