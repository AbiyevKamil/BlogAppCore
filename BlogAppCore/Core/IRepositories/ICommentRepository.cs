using BlogAppCore.Data.Entities;

namespace BlogAppCore.Core.IRepositories
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        public Task<IEnumerable<Comment>> GetByUserIdAsync(string id);
    }
}
