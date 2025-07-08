using BlogV3.Domain.Abstractions;
using MediatR;

namespace BlogV3.Application.Queries.Dashboard.GetDashboardPostList
{
    public class GetDashboardPostListQuery : IRequest<Result<GetDashboardPostListResponse>>
    {
    }
}