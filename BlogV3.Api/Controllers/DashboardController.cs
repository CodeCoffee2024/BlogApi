using BlogV3.Api.Shared;
using BlogV3.Application.Queries.Dashboard.GetCategoryMasterList;
using BlogV3.Application.Queries.Dashboard.GetDashboardPostList;
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

        #endregion Public Methods
    }
}