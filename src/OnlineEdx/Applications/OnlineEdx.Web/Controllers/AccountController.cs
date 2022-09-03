using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdx.Infrastructure.Entities.Membership;
using OnlineEdx.Membership.Services;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, ILifetimeScope scope,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IAccountService accountService)
            : base(logger, scope)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string returnUrl = null!)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = _scope.Resolve<RegisterModel>();
            model.ReturnUrl = returnUrl;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            model.ReturnUrl ??= Url.Content("~/");
            try
            {
                if (ModelState.IsValid)
                {
                    model.ResolveDependency(_scope);
                    var result = await model.CreateAccountAsync();

                    if (!result.Succeeded)
                    {

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(model);
                    }

                    ModelState.Clear();

                    await model.SignInAsync();
                    model.ReturnUrl ??= Url.Content("~/Home");
                    return LocalRedirect(model.ReturnUrl!);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View(model);
        }

        public IActionResult Login(string returnUrl = null!)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = _scope.Resolve<LoginModel>();

            try
            {
                if (!string.IsNullOrEmpty(model.ErrorMessage))
                {
                    ModelState.AddModelError(string.Empty, model.ErrorMessage);
                }

                returnUrl ??= Url.Content("~/");

                model.ReturnUrl = returnUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ResolveDependency(_scope);
                    var result = await model.PasswordSignInAsync();
                    if (result.Succeeded)
                    {
                        var roles = await model.GetCurrentUserRolesAsync();
                        if (roles.Contains("Admin"))
                        {
                            model.ReturnUrl ??= Url.Content("~/Admin/Dashboard");
                        }
                        else
                        {
                            model.ReturnUrl ??= Url.Content("~/Home");
                        }
                        return LocalRedirect(model.ReturnUrl!);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null!)
        {
            try
            {
                var model = _scope.Resolve<LogoutModel>();
                await model.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return RedirectToAction(typeof(Index).Name);
        }

    }
}
