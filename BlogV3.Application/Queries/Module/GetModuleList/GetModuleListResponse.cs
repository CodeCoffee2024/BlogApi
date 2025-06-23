using System.Collections;
using BlogV3.Application.Dtos;

namespace BlogV3.Application.Queries.Module.GetModuleList
{
    public sealed class GetModuleListResponse : IReadOnlyList<ModuleDto>
    {
        #region Fields

        private readonly IReadOnlyList<ModuleDto> _modules;

        #endregion Fields

        #region Public Constructors

        public GetModuleListResponse(IReadOnlyList<ModuleDto> modules)
        {
            _modules = modules;
        }

        #endregion Public Constructors

        #region Properties

        public int Count => _modules.Count;

        #endregion Properties

        #region Indexers

        public ModuleDto this[int index] => _modules[index];

        #endregion Indexers

        #region Public Methods

        public IEnumerator<ModuleDto> GetEnumerator() => _modules.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _modules.GetEnumerator();

        #endregion Public Methods
    }
}