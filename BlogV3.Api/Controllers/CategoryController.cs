using BlogV3.Api.Attributes;
using BlogV3.Api.Shared;
using BlogV3.Application.Commands.Category.DeleteCategory;
using BlogV3.Application.Queries.Category.GetOneCategory;
using BlogV3.Application.Requests;
using BlogV3.Common.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ApiBaseController
    {
        #region Public Constructors

        public CategoryController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("GetCategories")]
        [PermissionAuthorize(Modules.CATEGORY, Permissions.VIEW)]
        public async Task<IActionResult> GetListing([FromQuery] CategoryRequest request, CancellationToken cancellationToken)
        {
            var query = request.ToQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [PermissionAuthorize(Modules.CATEGORY, Permissions.MODIFY)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [PermissionAuthorize(Modules.CATEGORY, Permissions.MODIFY)]
        public async Task<IActionResult> Create([FromBody] CategoryRequest request, CancellationToken cancellationToken)
        {
            var command = request.SetAddCommand(UserId);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [PermissionAuthorize(Modules.CATEGORY, Permissions.VIEW)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new GetOneCategoryQuery(id);
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        #endregion Public Methods
    }
}