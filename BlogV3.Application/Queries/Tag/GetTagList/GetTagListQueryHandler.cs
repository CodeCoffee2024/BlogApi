using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Tag.GetTagList
{
    public class GetTagListQueryHandler(
        ITagRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetTagListQuery, Result<PageResult<GetTagListResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetTagListResponse>>> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _repository.GetPaginatedTagsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!);
            var mapped = _mapper.Map<IReadOnlyList<TagDto>>(pagedResult.Items);
            var wrapped = new GetTagListResponse(mapped);

            return Result.Success(
                new PageResult<GetTagListResponse>(
                    new List<GetTagListResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}