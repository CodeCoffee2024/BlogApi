using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetDashboardAdminSummary
{
    public class GetDashboardAdminSummaryQueryHandler(
        IPostRepository _postRepository,
        IUserRepository _userRepository
    ) : IRequestHandler<GetDashboardAdminSummaryQuery, Result<IEnumerable<DashboardAdminSummaryDto>>>
    {
        #region Public Methods

        public async Task<Result<IEnumerable<DashboardAdminSummaryDto>>> Handle(GetDashboardAdminSummaryQuery request, CancellationToken cancellationToken)
        {
            var activePostsCount = await _postRepository.GetActivePostsCount();
            var activeUsersCount = await _userRepository.GetActiveUsersCount();
            var newPostForWeekCount = await _postRepository.GetNewPostsForWeekCount();
            var newUserForWeekCount = await _userRepository.GetNewUsersForWeekCount();
            IEnumerable<DashboardAdminSummaryDto> resultHeader = new[]
            {
                new DashboardAdminSummaryDto { Label = "Post Count", Value = activePostsCount },
                new DashboardAdminSummaryDto { Label = "User Count", Value = activeUsersCount },
                new DashboardAdminSummaryDto { Label = "Post Count Per Week", Value = newPostForWeekCount },
                new DashboardAdminSummaryDto { Label = "User Count Per Week", Value = newUserForWeekCount }
            };
            return Result.Success(resultHeader);
        }

        #endregion Public Methods
    }
}