using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Claims;
using System.Text;
using OnlineEdx.Infrastructure.Entities.Membership;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using ApplicationUserBO = OnlineEdx.Infrastructure.BusinessObjects.ApplicationUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NHibernate;
using OnlineEdx.Data;

namespace OnlineEdx.Membership.Services
{
    public class AccountService : IAccountService, IDisposable
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ISession _session;
        private readonly IUrlHelper _urlHelper;
        private readonly IActionContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor contextAccessor,
            IMapper mapper, ISession session)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _urlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.ActionContext!);
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _session = session;
        }
        public async Task ClaimAsync(ApplicationUser user)
        {
            await _userManager.AddClaimAsync(user, new Claim("ViewTestPage", "true"));
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result;
        }

        public async Task<IdentityResult> CreateExternalUserAsync(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await RolesAsync(user);
            }

            return result;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUserBO user)
        {
            try
            {
                var userEntity = _mapper.Map<ApplicationUser>(user);
                _session.Save(await _userManager.CreateAsync(userEntity, user.Password));

                //var result = await _userManager.CreateAsync(userEntity, user.Password);

                //if (result.Succeeded)
                //{
                //    await RolesAsync(userEntity);
                //    await GenerateEmailConfirmationTokenAsync(userEntity);
                //}

                return null!;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = _urlHelper.Action(
            "ConfirmEmail",
            "Account",
            values: new
            {
                area = "",
                userId = user.Id,
                code = code,
            },
            protocol: _contextAccessor.ActionContext.HttpContext.Request.Scheme);

            await SendEmailConfirmationEmail(callbackUrl, user.Email);
        }

        public async Task GenerateForgotPasswordTokenAsync(ApplicationUser user)
        {
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(code))
            {
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = _urlHelper.Action(
                    "ResetPassword",
                    "Account",
                    values: new { userid = user.Id, code },
                    protocol: _contextAccessor.ActionContext.HttpContext.Request.Scheme);

                await SendForgotPasswordEmail(callbackUrl, user.Email);
            }
        }

        public async Task<IList<string>> GetCurrentUserRolesAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public string GetUserId()
        {
            return GetUser!.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public ClaimsPrincipal GetUser => _contextAccessor.ActionContext.HttpContext.User;

        public bool IsAuthenticated()
        {
            return GetUser!.Identity!.IsAuthenticated;
        }

        public async Task<SignInResult> PasswordSignInAsync(ApplicationUserBO user)
        {
            return await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe,
                lockoutOnFailure: false);
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUserBO user)
        {
            return await _userManager.ResetPasswordAsync
                (await _userManager.FindByIdAsync(user.Id.ToString()), user.Code, user.NewPassword);
        }

        public async Task RolesAsync(ApplicationUser user)
        {
            await _userManager.AddToRolesAsync(user, new string[] { "User" });
        }

        public Task SendEmailConfirmationEmail(string callbackUrl, string email)
        {
            throw new NotImplementedException();
        }

        public Task SendForgotPasswordEmail(string callbackUrl, string email)
        {
            throw new NotImplementedException();
        }

        public async Task SignInAsync(string email)
        {
            await _signInManager.SignInAsync(await _userManager.FindByEmailAsync(email), isPersistent: false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}
