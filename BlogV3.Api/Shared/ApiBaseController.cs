using System.Security.Claims;
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

        #endregion Public Constructors
    }
}