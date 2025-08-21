using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetPostsPerMonth
{
    public class GetPostsPerMonthQuery : IRequest<Result<DashboardChartDto>>
    {
        #region Public Constructors

        public GetPostsPerMonthQuery(
            DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        #endregion Public Constructors

        #region Properties

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        #endregion Properties
    }
}