using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;

namespace BlogAppCore.Core.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
