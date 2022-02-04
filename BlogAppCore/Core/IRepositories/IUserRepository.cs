using System.Security.Claims;
using BlogAppCore.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogAppCore.Core.IRepositories
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        public Task<IdentityResult> CreateAsync(AppUser user, string password);
        public Task<AppUser> FindByClaimsAsync(ClaimsPrincipal claims);
        public Task<AppUser> FindByEmailAsync(string email);

    }
}
