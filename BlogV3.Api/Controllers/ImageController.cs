using BlogV3.Api.Shared;
using BlogV3.Application.Queries.Image;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ImageController : ApiBaseController
    {
        #region Public Constructors

        public ImageController(ISender sender) : base(sender)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("{imageName}")]
        public async Task<IActionResult> GetListing([FromRoute] string imageName, CancellationToken cancellationToken)
        {
            var query = new GetImageQuery(imageName);
            var result = await _sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        #endregion Public Methods
    }
}