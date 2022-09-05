using Microsoft.AspNetCore.Identity;
using OnlineEdx.Infrastructure.Entities.Membership;
using ApplicationUserBO = OnlineEdx.Infrastructure.BusinessObjects.Membership.ApplicationUser;

namespace OnlineEdx.Membership.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUserBO user);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<ApplicationUser> GetUserAsync();
        Task<SignInResult> PasswordSignInAsync(ApplicationUserBO user);
        Task<IList<string>> GetCurrentUserRolesAsync(string email);
        Task RolesAsync(ApplicationUser user);
        Task SignInAsync(string email);
        Task SignOutAsync();
        bool IsAuthenticated();
        string GetUserId();
        Task<IdentityResult> ResetPasswordAsync(ApplicationUserBO user);
    }
}
