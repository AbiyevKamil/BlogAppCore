using BlogAppCore.Data.Entities;

namespace BlogAppCore.Core.IRepositories
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        public Task<IEnumerable<Blog>> GetByCategoryIdAsync(long id);
        public Task<IEnumerable<Blog>> GetByUserIdAsync(string id);
        public Task<IEnumerable<Blog>> GetDeletedBlogsByUserIdAsync(string id);
    }
}
