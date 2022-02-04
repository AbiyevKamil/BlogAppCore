using System.Security.Claims;
using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Core.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(BlogDbContext context, ILogger logger, UserManager<AppUser> userManager) : base(context, logger)
        {
            _userManager = userManager;
        }

        public virtual async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public virtual async Task<AppUser> FindByClaimsAsync(ClaimsPrincipal claims)
        {
            return await _userManager.GetUserAsync(claims);
        }

        public virtual async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
