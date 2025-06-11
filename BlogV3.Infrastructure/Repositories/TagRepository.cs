using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;

namespace BlogV3.Infrastructure.Repositories
{
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        #region Public Constructors

        public TagRepository(AppDbContext context) : base(context)
        {
        }

        #endregion Public Constructors
    }
}