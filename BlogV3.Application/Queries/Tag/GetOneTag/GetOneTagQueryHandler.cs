using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetOneTag
{
    public class GetOneTagQueryHandler(ITagRepository _repository, IMapper _mapper) : IRequestHandler<GetOneTagQuery, Result<TagDto>>
    {
        #region Public Methods

        public async Task<Result<TagDto>> Handle(GetOneTagQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure<TagDto>(Error.Notfound);
            }
            var mappedResult = _mapper.Map<TagDto>(result);
            return mappedResult;
        }

        #endregion Public Methods
    }
}