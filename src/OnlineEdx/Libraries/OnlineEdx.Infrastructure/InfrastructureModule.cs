using Autofac;
using NHibernate;
using OnlineEdx.Infrastructure.SessionFactories;
using OnlineEdx.Infrastructure.UnitOfWorks;

namespace OnlineEdx.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EdxUnitOfWork>().As<IEdxUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MsSQLSessionFactory>().As<ISessionFactory>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
