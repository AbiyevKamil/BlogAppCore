using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAppCore.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected BlogDbContext _context;
        protected ILogger _logger;
        protected DbSet<T> dbSet;


        public GenericRepository(BlogDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            dbSet = _context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} AddAsync method error", typeof(GenericRepository<T>));
                return false;
            }
        }


        // Need to change algorithm for other repositories.
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var exist = await dbSet.FindAsync(entity);
                if (exist == null)
                    return false;
                dbSet.Update(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} UpdateAsync method error", typeof(GenericRepository<T>));
                return false;
            }
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                var exist = await dbSet.FindAsync(id);
                if (exist == null)
                    return false;
                dbSet.Remove(exist);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} DeleteByIdAsync method error", typeof(GenericRepository<T>));
                return false;
            }
        }
    }
}
