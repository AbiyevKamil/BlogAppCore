using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppCore.Core.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public virtual async Task<IEnumerable<Blog>> GetByCategoryIdAsync(int id)
        {
            return await dbSet.Include(i =>
                i.CategoryId == id && !i.IsDeleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<Blog>> GetByUserIdAsync(string id)
        {
            return await dbSet.Include(i =>
                i.AppUserId == id && !i.IsDeleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<Blog>> GetDeletedBlogsByUserIdAsync(string id)
        {
            return await dbSet.Include(i =>
                i.AppUserId == id && i.IsDeleted).ToListAsync();
        }
    }
}
