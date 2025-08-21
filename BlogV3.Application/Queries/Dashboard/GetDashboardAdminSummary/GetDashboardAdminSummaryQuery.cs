using BlogV3.Application.Dtos;
using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetDashboardAdminSummary
{
    public class GetDashboardAdminSummaryQuery : IRequest<Result<IEnumerable<DashboardAdminSummaryDto>>>
    {
    }
}