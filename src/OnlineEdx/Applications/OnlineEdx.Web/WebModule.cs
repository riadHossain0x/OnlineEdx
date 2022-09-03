using Autofac;
using OnlineEdx.Web.Models;

namespace OnlineEdx.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();
            builder.RegisterType<RegisterModel>().AsSelf();
            builder.RegisterType<LogoutModel>().AsSelf();
            base.Load(builder);
        }
    }
}
