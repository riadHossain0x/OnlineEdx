using Autofac;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OnlineEdx.Membership.Services;

namespace OnlineEdx.Membership
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<ActionContextAccessor>().As<IActionContextAccessor>().SingleInstance();
            base.Load(builder);
        }
    }
}
