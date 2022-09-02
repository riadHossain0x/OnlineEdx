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
            builder.RegisterType<MsSQLSessionFactory>().As<IDataSessionFactory>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EdxUnitOfWork>().As<IEdxUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
