using BlogAppCore.Core.IRepositories;

namespace BlogAppCore.Core.IConfigurations
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ICommentRepository Comments { get; }
        public IBlogRepository Blogs { get; }
        public ICategoryRepository Categories { get; }

        public Task CompleteAsync();
    }
}
