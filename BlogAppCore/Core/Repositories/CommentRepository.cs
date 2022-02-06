using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppCore.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public virtual async Task<IEnumerable<Comment>> GetByUserIdAsync(string id)
        {
            return await _context.Comments.Include(i => i.AppUser).Include(i => i.Blog)
                .Where(i => i.AppUserId == id).ToListAsync();
        }
    }
}
