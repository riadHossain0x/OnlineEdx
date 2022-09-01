using Autofac;
using OnlineEdx.Data;
using OnlineEdx.Infrastructure.Repositories;
using OnlineEdx.Infrastructure.Services;
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
            builder.RegisterType<MsSQLSessionFactory>().As<IDataSessionFactory>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
