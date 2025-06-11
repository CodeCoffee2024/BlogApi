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

        #endregion Public Constructors
    }
}