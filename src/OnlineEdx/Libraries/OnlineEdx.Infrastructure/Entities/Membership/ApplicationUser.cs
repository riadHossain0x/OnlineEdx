using FluentNHibernate.AspNetCore.Identity;

namespace OnlineEdx.Infrastructure.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual string FirstName { get; set; } = null!;
        public virtual string LastName { get; set; } = null!;
        public virtual IList<Enroll>? Enrolls { get; set; } = null!;
    }
}
