using BlogV3.Application.Abstractions;
using BlogV3.Application.Commands.Module.CreateModule;
using BlogV3.Application.Commands.Module.UpdateModule;
using BlogV3.Application.Queries.Post.GetPostList;

namespace BlogV3.Application.Requests
{
    public class ModuleRequest : PageRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        #endregion Properties

        #region Public Methods

        public CreateModuleCommand SetAddCommand(Guid UserId) =>
            new(UserId, Name);

        public UpdateModuleCommand SetUpdateCommand(Guid UserId, Guid Id) =>
            new(UserId, Id, Name);

        public GetPostListQuery ToQuery() => new(Search, OrderBy, PageNumber, PageSize);

        #endregion Public Methods
    }
}