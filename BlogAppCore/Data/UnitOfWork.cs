using BlogAppCore.Core.IConfigurations;
using BlogAppCore.Core.IRepositories;
using BlogAppCore.Core.Repositories;
using BlogAppCore.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly BlogDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; }
        public ICommentRepository Comments { get; }
        public IBlogRepository Blogs { get; }
        public ICategoryRepository Categories { get; }

        public UnitOfWork(UserManager<AppUser> userManager, BlogDbContext context, ILoggerFactory factory)
        {
            _userManager = userManager;
            _context = context;
            _logger = factory.CreateLogger("Logger");

            Users = new UserRepository(_context, _logger, _userManager);
            Comments = new CommentRepository(_context, _logger);
            Blogs = new BlogRepository(_context, _logger);
            Categories = new CategoryRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
