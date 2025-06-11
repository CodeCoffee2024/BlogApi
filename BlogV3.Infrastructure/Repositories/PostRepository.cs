using BlogV3.Domain.Entities;
using BlogV3.Domain.Interfaces;
using BlogV3.Infrastructure.Data;

namespace BlogV3.Infrastructure.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        #region Public Constructors

        public PostRepository(AppDbContext context) : base(context)
        {
        }

        #endregion Public Constructors
    }
}