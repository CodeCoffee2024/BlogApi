using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Module.GetModuleList
{
    public class GetModuleListQueryHandler(
        IModuleRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetModuleListQuery, Result<PageResult<GetModuleListResponse>>>
    {
        #region Public Methods

        public async Task<Result<PageResult<GetModuleListResponse>>> Handle(GetModuleListQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _repository.GetPaginatedPostsAsync(
                request.PageNumber, request.PageSize, request.Search, request.OrderBy!);

            var mapped = _mapper.Map<IReadOnlyList<ModuleDto>>(pagedResult.Items);
            var wrapped = new GetModuleListResponse(mapped);

            return Result.Success(
                new PageResult<GetModuleListResponse>(
                    new List<GetModuleListResponse> { wrapped },
                    pagedResult.TotalCount,
                    pagedResult.PageNumber,
                    pagedResult.PageSize,
                    pagedResult.OrderBy)
            );
        }

        #endregion Public Methods
    }
}