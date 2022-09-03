using OnlineEdx.Membership.Services;

namespace OnlineEdx.Web.Models
{
    public class LogoutModel : BaseModel
    {
        private readonly IAccountService _accountService;

        public LogoutModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }
    }
}
