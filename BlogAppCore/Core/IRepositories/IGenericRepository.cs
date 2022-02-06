namespace BlogAppCore.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(long id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<bool> AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteByIdAsync(long id);

    }
}
