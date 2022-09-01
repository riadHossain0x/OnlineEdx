using Microsoft.AspNetCore.Identity;
using NHibernate;

namespace OnlineEdx.Membership.Services
{
    public class IdentityStore : IUserStore<User>,
        IUserPasswordStore<User>
    {
        private readonly ISession _session;

        public IdentityStore(ISession session)
        {
            _session = session;
        }
        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _session.SaveOrUpdateAsync(user);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken = default)
        {
            await _session.DeleteAsync(user, cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            return await _session.GetAsync<User>(userId);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
        {
            return Task.Run(() =>
            {
                return _session.QueryOver<User>()
                        .Where(u => u.UserName == normalizedUserName)
                        .SingleOrDefault();
            });
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _session.SaveOrUpdateAsync(user);
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => user.PasswordHash = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
