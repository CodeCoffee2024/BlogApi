using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetDashboardPostList
{
    public class GetDashboardPostListQueryHandler(
        IPostRepository _repository,
        IMapper _mapper
    ) : IRequestHandler<GetDashboardPostListQuery, Result<GetDashboardPostListResponse>>
    {
        #region Public Methods

        public async Task<Result<GetDashboardPostListResponse>> Handle(GetDashboardPostListQuery request, CancellationToken cancellationToken)
        {
            var top4 = await _repository.GetTop4();
            var highlight = await _repository.GetHighlights();
            var top2 = await _repository.GetTop2();
            var latest = await _repository.GetLatest();

            return Result.Success(new GetDashboardPostListResponse(
                _mapper.Map<IEnumerable<PostDto>>(top4),
                _mapper.Map<IEnumerable<PostDto>>(highlight),
                _mapper.Map<IEnumerable<PostDto>>(top2),
                _mapper.Map<IEnumerable<PostDto>>(latest)));
        }

        #endregion Public Methods
    }
}