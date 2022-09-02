using Microsoft.AspNetCore.Identity;
using OnlineEdx.Infrastructure.Entities.Membership;
using ApplicationUserBO = OnlineEdx.Infrastructure.BusinessObjects.ApplicationUser;

namespace OnlineEdx.Membership.Services
{
    public interface IAccountService
    {
        Task<object> CreateUserAsync(ApplicationUserBO user);
        Task<IdentityResult> CreateExternalUserAsync(ApplicationUser user);
        Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task SendEmailConfirmationEmail(string callbackUrl, string email);
        Task SendForgotPasswordEmail(string callbackUrl, string email);
        Task<IdentityResult> ConfirmEmailAsync(string userId, string code);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<SignInResult> PasswordSignInAsync(ApplicationUserBO user);
        Task<IList<string>> GetCurrentUserRolesAsync(string email);
        Task RolesAsync(ApplicationUser user);
        Task ClaimAsync(ApplicationUser user);
        Task SignInAsync(string email);
        Task SignOutAsync();
        bool IsAuthenticated();
        string GetUserId();
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);
        Task<IdentityResult> ResetPasswordAsync(ApplicationUserBO user);
    }
}
