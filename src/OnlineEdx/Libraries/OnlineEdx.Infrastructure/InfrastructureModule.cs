using Autofac;
using OnlineEdx.Infrastructure.Services;

namespace OnlineEdx.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseService>().As<ICourseService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
