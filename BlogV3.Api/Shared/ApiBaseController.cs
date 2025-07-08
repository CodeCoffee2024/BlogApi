using System.Security.Claims;
using BlogV3.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogV3.Api.Shared
{
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {
        #region Fields

        protected readonly ISender _sender;

        #endregion Fields

        #region Public Constructors

        public ApiBaseController(ISender sender) => _sender = sender;

        protected Guid UserId
        {
            get
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Guid.TryParse(userId, out var id)
                    ? id
                    : throw new UnauthorizedAccessException("Invalid or missing user ID in token.");
            }
        }

        protected IActionResult HandleResponse<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return result.Data != null ? Ok(result) : NotFound(result);
        }

        protected IActionResult HandleResponse(Result result)
        {
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        #endregion Public Constructors
    }
}