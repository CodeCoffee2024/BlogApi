using BlogV3.Api.Shared;
using BlogV3.Application.Queries.Dashboard.GetCategoryMasterList;
using BlogV3.Application.Queries.Dashboard.GetDashboardAdminSummary;
using BlogV3.Application.Queries.Dashboard.GetDashboardPostList;
using BlogV3.Application.Queries.Dashboard.GetPostsPerMonth;
using BlogV3.Application.Queries.Dashboard.GetUsersPerMonth;
using BlogV3.Application.Queries.Post.GetOnePost;
using BlogV3.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ApiBaseController
    {
        #region Public Constructors

        public DashboardController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("Categories")]
        public async Task<IActionResult> Categories(CancellationToken cancellationToken)
        {
            var command = new GetCategoryMasterListQuery();
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("Posts")]
        public async Task<IActionResult> Posts(CancellationToken cancellationToken)
        {
            var command = new GetDashboardPostListQuery();
            var result = await _sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetPostsByCategory/{name}")]
        public async Task<IActionResult> GetListing([FromRoute] string name, [FromQuery] PostRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToDashboardQuery(name);
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id, [FromQuery] PostRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOnePostQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetDashboardAdminSummary")]
        public async Task<IActionResult> GetDashboardAdminSummary(CancellationToken cancellationToken)
        {
            var query = new GetDashboardAdminSummaryQuery();
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetUsersPerMonth/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetUsersPerMonth([FromRoute] DateTime dateFrom, [FromRoute] DateTime dateTo, CancellationToken cancellationToken)
        {
            var query = new GetUsersPerMonthQuery(dateFrom, dateTo);
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [HttpGet("GetPostsPerMonth/{dateFrom}/{dateTo}")]
        public async Task<IActionResult> GetPostsPerMonth([FromRoute] DateTime dateFrom, [FromRoute] DateTime dateTo, CancellationToken cancellationToken)
        {
            var query = new GetPostsPerMonthQuery(dateFrom, dateTo);
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}