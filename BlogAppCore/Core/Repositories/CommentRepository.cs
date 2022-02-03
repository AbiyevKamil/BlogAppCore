using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;

namespace BlogAppCore.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
