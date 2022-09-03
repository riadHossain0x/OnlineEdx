using Autofac;
using OnlineEdx.Membership.Services;

namespace OnlineEdx.Web.Models
{
    public class LogoutModel : BaseModel
    {
        private IAccountService _accountService;

        public LogoutModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _accountService = _scope.Resolve<IAccountService>();
            base.ResolveDependency(scope);
        }

        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }
    }
}
