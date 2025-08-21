using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using BlogV3.Domain.Interfaces;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetPostsPerMonth
{
    public class GetPostsPerMonthQueryHandler(
        IPostRepository _postRepository
    ) : IRequestHandler<GetPostsPerMonthQuery, Result<DashboardChartDto>>
    {
        #region Public Methods

        public async Task<Result<DashboardChartDto>> Handle(GetPostsPerMonthQuery request, CancellationToken cancellationToken)
        {
            var activeUsersCount = await _postRepository.GetActivePostsCount();

            if (request.DateFrom > request.DateTo)
            {
                return Result.Failure<DashboardChartDto>(Error.InvalidRequest);
            }

            var users = await _postRepository.GetPostsByDateRangeAsync(
                request.DateFrom,
                request.DateTo,
                cancellationToken);

            var usersPerMonth = users
                .GroupBy(u => new { u.CreatedOn.Value.Year, u.CreatedOn.Value.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();
            var monthLabels = new List<string>();
            var monthValues = new List<object>();

            var start = new DateTime(request.DateFrom.Year, request.DateFrom.Month, 1);
            var end = new DateTime(request.DateTo.Year, request.DateTo.Month, 1);

            for (var date = start; date <= end; date = date.AddMonths(1))
            {
                monthLabels.Add(date.ToString("MMM yyyy"));

                var monthCount = usersPerMonth
                    .FirstOrDefault(x => x.Year == date.Year && x.Month == date.Month)?.Count ?? 0;

                monthValues.Add(monthCount);
            }
            var resultHeader = new DashboardChartDto
            {
                Title = "Posts Per Month",
                Labels = monthLabels,
                Values = monthValues
            };

            return Result.Success(resultHeader);
        }

        #endregion Public Methods
    }
}